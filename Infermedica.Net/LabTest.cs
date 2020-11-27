using System.Collections.Generic;
using Newtonsoft.Json;

namespace Infermedica.Net
{
    public class LabTest
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("common_name")]
        public string CommonName { get; set; }
        
        [JsonProperty("category")]
        public string Category { get; set; }
        
        [JsonProperty("results")]
        public List<LabResult> Results { get; set; }
    }
    
}