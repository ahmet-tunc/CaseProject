using Core.Entities.Concrete;
using System.Collections.Generic;

namespace CaseProject.WebAPI.Models
{
    public class HistoryCategoryModel:EntityBase
    {
        public string Name { get; set; }
        public int LanguageId { get; set; }
    }
}
