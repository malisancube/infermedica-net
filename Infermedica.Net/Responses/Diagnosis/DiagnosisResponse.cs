using System.Collections.Generic;
using Newtonsoft.Json;

namespace Infermedica.Net
{
    public class DiagnosisResponse
    {
        [JsonProperty("question")]
        public Question Question { get; set; }
        
        [JsonProperty("conditions")]
        public List<ConditionResponse> Conditions { get; set; }
        
        [JsonProperty("should_stop")]
        public bool ShouldStop { get; set; }
        
        [JsonProperty("extras")]
        public DiagnosisExtras Extras { get; set; }
    }
}