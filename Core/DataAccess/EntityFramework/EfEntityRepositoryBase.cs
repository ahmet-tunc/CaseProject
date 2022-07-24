using CaseProject.Core.Utilities.Results.Abstract;
using Core.Constants;
using Core.Entities.Abstract;
using Core.Utilities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {

        protected TContext _DbContext;
        private DbSet<TEntity> DbSet => _DbContext.Set<TEntity>();
        public virtual IQueryable<TEntity> QueryInclude => DbSet;

        public EfEntityRepositoryBase(TContext DbContext)
        {
            _DbContext = DbContext;
        }
        public async Task<IDataResult<TEntity>> AddAsync(TEntity entity)
        {
            using (var context = new TContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                await context.SaveChangesAsync();
                return new SuccessDataResult<TEntity>(entity, Messages.Added(typeof(TEntity).Name));
            }
        }

        public async Task<IResult> AddListAsync(List<TEntity> entity)
        {
            using var context = new TContext();
            context.Set<TEntity>().AddRange(entity);
            await context.SaveChangesAsync();
            return new SuccessResult(Messages.AddedList(typeof(TEntity).Name));
        }


        public async Task<IDataResult<List<TEntity>>> GetAllAsync(int page, int pagesize, bool includeRelationships = false, Expression<Func<TEntity, bool>> filter = null)
        {
            using var context = new TContext();
            if (includeRelationships)
            {
                var includeRelationShipsList = filter != null ?
                    QueryInclude.Where(filter).Skip((page-1)*pagesize).Take(pagesize).ToList() :
                    QueryInclude.Skip((page - 1) * pagesize).Take(pagesize).ToList();
                return new SuccessDataResult<List<TEntity>>(includeRelationShipsList, Messages.Listed(typeof(TEntity).Name));
            }
            var list = filter != null ?
            context.Set<TEntity>().Where(filter).Skip((page - 1) * pagesize).Take(pagesize).ToList() :
            context.Set<TEntity>().Skip((page - 1) * pagesize).Take(pagesize).ToList();
            return new SuccessDataResult<List<TEntity>>(list, Messages.Listed(typeof(TEntity).Name));
        }

        public async Task<IDataResult<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter, bool includeRelationships = false)
        {
            using var context = new TContext();
            if (includeRelationships)
            {
                var entity = await QueryInclude.SingleOrDefaultAsync(filter);
                if (entity != null)
                {
                    return new SuccessDataResult<TEntity>(entity, Messages.Listed(typeof(TEntity).Name));
                }
                return new ErrorDataResult<TEntity>(entity, Messages.NotFound(typeof(TEntity).Name));
            }
            var model = await context.Set<TEntity>().SingleOrDefaultAsync(filter);
            if (model != null)
            {
                return new SuccessDataResult<TEntity>(model, Messages.Listed(typeof(TEntity).Name));
            }
            return new ErrorDataResult<TEntity>(model, Messages.NotFound(typeof(TEntity).Name));
        }

        public async Task<IResult> UpdateAsync(TEntity entity)
        {
            using (var context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                await context.SaveChangesAsync();
                return new SuccessResult(Messages.Updated(typeof(TEntity).Name));
            }
        }

        public async Task<IResult> DeleteAsync(Expression<Func<TEntity, bool>> filter)
        {
            using (var context = new TContext())
            {
                var model = context.Set<TEntity>().FirstOrDefault(filter);
                if (model != null)
                {
                    var deletedEntity = context.Entry(model);
                    deletedEntity.State = EntityState.Deleted;
                    await context.SaveChangesAsync();
                    return new SuccessResult(Messages.Deleted(typeof(TEntity).Name));
                }
                return new ErrorResult(Messages.NotFound(typeof(TEntity).Name));
            }
        }

        public async Task<IResult> DeleteListAsync(List<TEntity> entity)
        {
            using (var context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                await context.SaveChangesAsync();
                return new SuccessResult(Messages.Deleted(typeof(TEntity).Name));
            }
        }

        public async Task<IResult> UpdateListAsync(List<TEntity> entity)
        {
            using (var context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                await context.SaveChangesAsync();
                return new SuccessResult(Messages.Updated(typeof(TEntity).Name));
            }
        }

        public async Task<IResult> DeleteListAsync(Expression<Func<TEntity, bool>> filter)
        {
            using (var context = new TContext())
            {
                var listModel = context.Set<TEntity>().Where(filter).ToList();
                if (listModel == null && listModel.Count == 0)
                {
                    return new ErrorResult(Messages.NotFound(typeof(TEntity).Name));
                }
                context.Set<TEntity>().RemoveRange(listModel);
                await context.SaveChangesAsync();
                return new SuccessResult(Messages.Deleted(typeof(TEntity).Name));
            }
        }
    }
}
