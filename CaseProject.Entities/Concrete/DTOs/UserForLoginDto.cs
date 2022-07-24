using Core.Entities.Abstract;

namespace CaseProject.Entities.Concrete.DTOs
{
    public class UserForLoginDto:IDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
