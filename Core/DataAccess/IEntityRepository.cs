using CaseProject.Core.Utilities.Results.Abstract;
using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    public interface IEntityRepository<T> where T:class, IEntity ,new()
    {
        Task<IDataResult<T>> AddAsync(T entity);
        Task<IResult> AddListAsync(List<T> entity);
        Task<IResult> DeleteAsync(Expression<Func<T, bool>> filter);
        Task<IResult> DeleteListAsync(Expression<Func<T, bool>> filter);
        Task<IResult> UpdateAsync(T entity);
        Task<IResult> UpdateListAsync(List<T> entity);
        Task<IDataResult<T>> GetAsync(Expression<Func<T, bool>> filter, bool includeRelationships = false);
        Task<IDataResult<List<T>>> GetAllAsync(int page, int pagesize, bool includeRelationships = false, Expression<Func<T, bool>> filter = null);
    }
}
