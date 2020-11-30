using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Infermedica.Net
{
    public class DiagnosisResponse
    {
        [JsonPropertyName("question")]
        public Question Question { get; set; }
        
        [JsonPropertyName("conditions")]
        public List<ConditionResponse> Conditions { get; set; }
        
        [JsonPropertyName("should_stop")]
        public bool ShouldStop { get; set; }
        
        [JsonPropertyName("extras")]
        public DiagnosisExtras Extras { get; set; }
    }
}