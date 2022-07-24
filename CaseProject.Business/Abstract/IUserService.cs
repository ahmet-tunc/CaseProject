using CaseProject.Business.Abstract.BaseServices;
using CaseProject.Core.Utilities.Results.Abstract;
using Core.Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CaseProject.Business.Abstract
{
    public interface IUserService:IBaseService<User>
    {
        Task<IDataResult<List<Role>>> GetClaims(User user);
        Task<IDataResult<User>> GetByMail(string email);
        Task<IResult> AddUserAsync(User user);
    }
}
