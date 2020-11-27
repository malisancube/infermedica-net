using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Infermedica.Net
{
    public class Condition
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("common_name")]
        public string CommonName { get; set; }
        
        [JsonProperty("sex_filter")]
        public string SexFilter { get; set; }
        
        [JsonProperty("categories")]
        public List<string> Categories { get; set; }
        
        [JsonProperty("prevalence")]
        public string Prevalence { get; set; }
        
        [JsonProperty("acuteness")]
        public string Acuteness { get; set; }
        
        [JsonProperty("severity")]
        public string Severity { get; set; }
        
        [JsonProperty("extras")]
        public Extras Extras { get; set; }
        
        [JsonProperty("triage_level")]
        public string TriageLevel { get; set; }
    }
}