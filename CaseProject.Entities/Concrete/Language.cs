using Core.Entities.Concrete;

namespace CaseProject.Entities.Concrete
{
    public class Language:EntityBase
    {
        public string Name { get; set; }
        public string ShortName { get; set; }
        public User CreatedUser { get; set; }
        public User UpdatedUser { get; set; }
    }
}
