using Newtonsoft.Json;

namespace Infermedica.Net
{
    public class DiagnosisRequest : TriageRequest
    {
        [JsonProperty("extras")]
        public DiagnosisExtras Extras { get; set; }
    }
}