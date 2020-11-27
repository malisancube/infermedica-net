using Newtonsoft.Json;

namespace Infermedica.Net
{
    public class Extras
    {
        [JsonProperty("hint")]
        public string Hint { get; set; }
        
        [JsonProperty("icd10_code")]
        public object Icd10Code { get; set; }
        
        [JsonProperty("disable_groups")]
        public bool? DisableGroups { get; set; }
    }
}