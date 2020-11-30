using System.Text.Json.Serialization;

namespace Infermedica.Net
{
    public class DiagnosisExtras
    {
        [JsonPropertyName("disable_groups")]
        public bool? DisableGroups { get; set; }
    }
}