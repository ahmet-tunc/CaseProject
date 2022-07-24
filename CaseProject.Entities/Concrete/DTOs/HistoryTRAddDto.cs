using Newtonsoft.Json;

namespace CaseProject.Entities.Concrete.DTOs
{
    public class HistoryTRAddDto
    {
        [JsonProperty("dc_zaman")]
        public string Date { get; set; }

        [JsonProperty("dc_Kategori")]
        public string CategoryName { get; set; }

        [JsonProperty("dc_Olay")]
        public string EventDescription { get; set; }
        public int LanguageId { get; set; } = 1;
    }
}
