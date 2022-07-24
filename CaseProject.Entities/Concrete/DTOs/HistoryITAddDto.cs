using Newtonsoft.Json;

namespace CaseProject.Entities.Concrete.DTOs
{
    public class HistoryITAddDto
    {
        [JsonProperty("dc_Orario")]
        public string Date { get; set; }

        [JsonProperty("dc_Categoria")]
        public string CategoryName { get; set; }

        [JsonProperty("dc_Evento")]
        public string EventDescription { get; set; }

        public int LanguageId { get; set; } = 2;
    }
}
