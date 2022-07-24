using Core.Entities.Concrete;
using System.ComponentModel.DataAnnotations.Schema;

namespace CaseProject.Entities.Concrete
{
    public class History:EntityBase
    {
        public string Date { get; set; }
        public string EventDescription { get; set; }

        [NotMapped]
        public string CategoryName { get; set; }

        public int HistoryCategoryId { get; set; }
        public HistoryCategory HistoryCategory { get; set; }

        public int LanguageId { get; set; }
        public Language Language { get; set; }

        public User CreatedUser { get; set; }
        public User UpdatedUser { get; set; }

    }
}
