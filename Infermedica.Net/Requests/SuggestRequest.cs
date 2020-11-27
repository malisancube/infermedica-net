using System.Collections.Generic;
using Newtonsoft.Json;

namespace Infermedica.Net
{
    public class SuggestRequest : TriageRequest
    {
        [JsonProperty("extras")]
        public Extras Extras { get; set; }
        
        [JsonProperty("evaluated_at")]
        public string EvaluatedAt { get; set; }
    }
}