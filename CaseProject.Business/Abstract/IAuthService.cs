using CaseProject.Core.Utilities.Results.Abstract;
using CaseProject.Entities.Concrete.DTOs;
using Core.Entities.Concrete;
using Core.Utilities.Security.Jwt.Concrete;

namespace CaseProject.Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<User> Register(UserForRegisterDto userForRegisterDto);
        IDataResult<User> Login(UserForLoginDto userForLoginDto);
        IResult UserExists(string email);
        IDataResult<AccessToken> CreateAccessToken(User user);
    }
}
