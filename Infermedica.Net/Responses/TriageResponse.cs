using System.Collections.Generic;
using Newtonsoft.Json;

namespace Infermedica.Net
{
    public class TriageResponse
    {
        [JsonProperty("triage_level")]
        public string TriageLevel { get; set; }
        
        [JsonProperty("serious")]
        public List<Serious> Serious { get; set; }
    }
}