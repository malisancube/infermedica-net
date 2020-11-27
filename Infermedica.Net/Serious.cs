using Newtonsoft.Json;

namespace Infermedica.Net
{
    public class Serious
    {
        [JsonProperty("id")]
        public string Id { get; set; }
 
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("common_name")]
        public string CommonName { get; set; }
        
        [JsonProperty("is_emergency")]
        public bool IsEmergency { get; set; }
    }
}