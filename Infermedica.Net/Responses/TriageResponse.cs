using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Infermedica.Net
{
    public class TriageResponse
    {
        [JsonPropertyName("triage_level")]
        public string TriageLevel { get; set; }
        
        [JsonPropertyName("serious")]
        public List<Serious> Serious { get; set; }
    }
}