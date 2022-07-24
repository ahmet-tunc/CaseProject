using Core.Entities.Concrete;
using System.Collections.Generic;

namespace CaseProject.Entities.Concrete
{
    public class HistoryCategory:EntityBase
    {
        public string Name { get; set; }
        public int LanguageId { get; set; }
    }
}
