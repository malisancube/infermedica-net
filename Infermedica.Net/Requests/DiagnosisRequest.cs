using System.Text.Json.Serialization;

namespace Infermedica.Net
{
    public class DiagnosisRequest : TriageRequest
    {
        [JsonPropertyName("extras")]
        public DiagnosisExtras Extras { get; set; }
    }
}