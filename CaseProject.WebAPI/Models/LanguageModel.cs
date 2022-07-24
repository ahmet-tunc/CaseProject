using Core.Entities.Concrete;

namespace CaseProject.WebAPI.Models
{
    public class LanguageModel:EntityBase
    {
        public string Name { get; set; }
        public string ShortName { get; set; }
        public User CreatedUser { get; set; }
        public User UpdatedUser { get; set; }
    }
}
