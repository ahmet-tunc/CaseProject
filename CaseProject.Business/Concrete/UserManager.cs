using CaseProject.Business.Abstract;
using CaseProject.Business.Concrete.BaseManagers;
using CaseProject.Business.Constants;
using CaseProject.Core.Utilities.Results.Abstract;
using CaseProject.DataAccess.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CaseProject.Business.Concrete
{
    public class UserManager : BaseManager<User>,IUserService
    {
        private readonly IUserDal _userDal;

        public UserManager(IUserDal userDal):base(userDal)
        {
            _userDal = userDal;
        }

        public async Task<IDataResult<User>> GetByMail(string email)
        {
            var model = _userDal.GetAsync(x => x.Email == email).Result;
            if (model.Success)
                return new SuccessDataResult<User>(model.Data, Messages.GetUser);

            return new ErrorDataResult<User>(Messages.UserNotFound);
        }

        public Task<IDataResult<List<Role>>> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }

        public async Task<IResult> AddUserAsync(User user)
        {
            var result = await _userDal.AddAsync(user);
            if (result.Success)
                return new SuccessResult();

            return new ErrorResult();
        }
    }
}
