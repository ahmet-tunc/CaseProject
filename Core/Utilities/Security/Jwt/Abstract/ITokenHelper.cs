using Core.Entities.Concrete;
using Core.Utilities.Security.Jwt.Concrete;
using System.Collections.Generic;

namespace Core.Utilities.Security.Jwt.Abstract
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user, List<Role> roles);
    }
}
