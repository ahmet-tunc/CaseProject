using CaseProject.Business.Abstract.BaseServices;
using CaseProject.Core.Aspects.Autofac.CacheAspects;
using CaseProject.Core.Utilities.Results.Abstract;
using Core.DataAccess;
using Core.Entities.Abstract;
using Core.Utilities.Concrete;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseProject.Business.Concrete.BaseManagers
{
    public class BaseManager<T>:IBaseService<T> where T:class, IEntity ,new()
    {
        private readonly IEntityRepository<T> _entityRepository;
        public BaseManager(IEntityRepository<T> entityRepository)
        {
            _entityRepository = entityRepository;
        }

        public virtual async Task<IDataResult<T>> AddAsync(T entity, int lang)
        {
            return await _entityRepository.AddAsync(entity);
        }

        public virtual async Task<IResult> AddListAsync(List<T> listEntity, int lang)
        {
            return await _entityRepository.AddListAsync(listEntity);
        }

        public virtual async Task<IResult> DeleteAsync(int id, int lang)
        {
            return await _entityRepository.DeleteAsync(x => x.Id == id);
        }

        public virtual async Task<IResult> DeleteListAsync(int[] id, int lang)
        {
            if (id != null && id.Length > 0)
            {
                return await _entityRepository.DeleteListAsync(x => id.Contains(x.Id));
            }
            return new ErrorResult();
        }


        [CacheAspect(duration:10)]
        public virtual async Task<IDataResult<List<T>>> GetAllAsync(int page, int pagesize, int lang, bool includeRelationShips = false)
        {
            return await _entityRepository.GetAllAsync(page, pagesize,includeRelationShips);
        }

        public virtual async Task<IDataResult<T>> GetByIdAsync(int id, int lang, bool includeRelationShips = false)
        {
            return await _entityRepository.GetAsync(x => x.Id == id, includeRelationShips);
        }

        public virtual async Task<IResult> UpdateAsync(T entity)
        {
            return await _entityRepository.UpdateAsync(entity);
        }

    }
}
