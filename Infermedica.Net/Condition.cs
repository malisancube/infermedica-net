using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Infermedica.Net
{
    public class Condition
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        
        [JsonPropertyName("name")]
        public string Name { get; set; }
        
        [JsonPropertyName("common_name")]
        public string CommonName { get; set; }
        
        [JsonPropertyName("sex_filter")]
        public string SexFilter { get; set; }
        
        [JsonPropertyName("categories")]
        public List<string> Categories { get; set; }
        
        [JsonPropertyName("prevalence")]
        public string Prevalence { get; set; }
        
        [JsonPropertyName("acuteness")]
        public string Acuteness { get; set; }
        
        [JsonPropertyName("severity")]
        public string Severity { get; set; }
        
        [JsonPropertyName("extras")]
        public Extras Extras { get; set; }
        
        [JsonPropertyName("triage_level")]
        public string TriageLevel { get; set; }
    }
}