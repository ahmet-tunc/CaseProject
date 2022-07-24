using CaseProject.Core.Utilities.Results.Abstract;
using Core.DataAccess;
using Core.Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CaseProject.DataAccess.Abstract
{
    public interface IUserDal:IEntityRepository<User>
    {
        Task<IDataResult<List<Role>>> GetClaims(User user);
    }
}
