using Newtonsoft.Json;

namespace Infermedica.Net
{
    public class DiagnosisExtras
    {
        [JsonProperty("disable_groups")]
        public bool? DisableGroups { get; set; }
    }
}