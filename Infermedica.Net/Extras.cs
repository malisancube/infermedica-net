using System.Text.Json.Serialization;

namespace Infermedica.Net
{
    public class Extras
    {
        [JsonPropertyName("hint")]
        public string Hint { get; set; }
        
        [JsonPropertyName("icd10_code")]
        public object Icd10Code { get; set; }
        
        [JsonPropertyName("disable_groups")]
        public bool? DisableGroups { get; set; }
    }
}