using CaseProject.Core.Utilities.Results.Abstract;
using Core.Entities.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CaseProject.Business.Abstract.BaseServices
{
    public interface IBaseService<T> where T: class, IEntity, new()
    {
        Task<IDataResult<T>> AddAsync(T entity, int lang);
        Task<IResult> AddListAsync(List<T> entity, int lang);
        Task<IResult> UpdateAsync(T entity);
        Task<IDataResult<T>> GetByIdAsync(int id, int lang, bool includeRelationShips = false);
        Task<IResult> DeleteAsync(int id, int lang);
        Task<IResult> DeleteListAsync(int[] id, int lang);
        Task<IDataResult<List<T>>> GetAllAsync(int page, int pagesize, int lang, bool includeRelationShips = false);
    }
}
