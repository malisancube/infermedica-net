using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Infermedica.Net
{
    public class TriageRequest
    {
        [JsonPropertyName("sex")]
        public string Sex { get; set; }
        
        [JsonPropertyName("age")]
        public int Age { get; set; }
        
        [JsonPropertyName("evidence")]
        public List<Evidence> Evidence { get; set; }
    }
}