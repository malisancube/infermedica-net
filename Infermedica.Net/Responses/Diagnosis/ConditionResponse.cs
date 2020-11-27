using Newtonsoft.Json;

namespace Infermedica.Net
{
    public class ConditionResponse
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("common_name")]
        public string CommonName { get; set; }
        
        [JsonProperty("probability")]
        public double Probability { get; set; }
    }
}