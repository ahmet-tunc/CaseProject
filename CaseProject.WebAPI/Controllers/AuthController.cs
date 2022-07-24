using CaseProject.Business.Abstract;
using CaseProject.Entities.Concrete.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CaseProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public ActionResult Login(UserForLoginDto userForLoginDto)
        {
            var userToLogin = _authService.Login(userForLoginDto);
            if (!userToLogin.Success)
                return BadRequest(userToLogin.Message);

            var result = _authService.CreateAccessToken(userToLogin.Data);
            if (!result.Success)
                return BadRequest(result.Message);

            return Ok(new
            {
                Success = result.Success,
                Message = result.Message,
                Data = result.Data
            });
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public ActionResult Register(UserForRegisterDto userForRegisterDto)
        {
            var userExists = _authService.UserExists(userForRegisterDto.Email);
            if (!userExists.Success)
                return StatusCode(Response.StatusCode, (new
                {
                    Success = userExists.Success,
                    Message = userExists.Message,
                }));

            var userToRegister = _authService.Register(userForRegisterDto);
            if (!userToRegister.Success)
            {
                return StatusCode(Response.StatusCode, (new
                {
                    Success = userToRegister.Success,
                    Message = userToRegister.Message,
                }));
            }
            var result = _authService.CreateAccessToken(userToRegister.Data);
            if (!result.Success)
            {
                return StatusCode(Response.StatusCode, (new
                {
                    Success = result.Success,
                    Message = result.Message,
                }));
            }
            return Ok(new
            {
                Success = result.Success,
                Message = result.Message,
                Data = result.Data
            });
        }
    }
}
