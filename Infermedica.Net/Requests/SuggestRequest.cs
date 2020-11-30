using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Infermedica.Net
{
    public class SuggestRequest : TriageRequest
    {
        [JsonPropertyName("extras")]
        public Extras Extras { get; set; }
        
        [JsonPropertyName("evaluated_at")]
        public string EvaluatedAt { get; set; }
    }
}