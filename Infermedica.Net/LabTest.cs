using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Infermedica.Net
{
    public class LabTest
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        
        [JsonPropertyName("name")]
        public string Name { get; set; }
        
        [JsonPropertyName("common_name")]
        public string CommonName { get; set; }
        
        [JsonPropertyName("category")]
        public string Category { get; set; }
        
        [JsonPropertyName("results")]
        public List<LabResult> Results { get; set; }
    }
    
}