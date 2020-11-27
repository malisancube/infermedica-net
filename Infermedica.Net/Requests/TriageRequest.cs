using System.Collections.Generic;
using Newtonsoft.Json;

namespace Infermedica.Net
{
    public class TriageRequest
    {
        [JsonProperty("sex")]
        public string Sex { get; set; }
        
        [JsonProperty("age")]
        public int Age { get; set; }
        
        [JsonProperty("evidence")]
        public List<Evidence> Evidence { get; set; }
    }
}