using Core.Entities.Concrete;

namespace CaseProject.WebAPI.Models
{
    public class HistoryModel:EntityBase
    {
        public string Date { get; set; }
        public string EventDescription { get; set; }
        public string CategoryName { get; set; }
        public int HistoryCategoryId { get; set; }
        public int LanguageId { get; set; }

    }
}
