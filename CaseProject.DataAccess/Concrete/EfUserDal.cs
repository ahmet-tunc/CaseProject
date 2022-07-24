using CaseProject.Core.Utilities.Results.Abstract;
using CaseProject.DataAccess.Abstract;
using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using Core.Utilities.Concrete;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseProject.DataAccess.Concrete
{
    public class EfUserDal : EfEntityRepositoryBase<User,AppDbContext>, IUserDal
    {

        public override IQueryable<User> QueryInclude => base.QueryInclude;

        public EfUserDal(AppDbContext context):base(context)
        {
        }

        public Task<IDataResult<List<Role>>> GetClaims(User user)
        {
            using var context = new AppDbContext();
            var result = from role in context.Roles
                         join userRole in context.UserRoles on role.Id equals userRole.RoleId
                         where userRole.UserId == user.Id
                         select new Role
                         {
                             Id = role.Id,
                             Name = role.Name
                         };

            return Task.FromResult<IDataResult<List<Role>>>(new SuccessDataResult<List<Role>>(result.ToList()));
        }
    }
}
