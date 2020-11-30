using System.Text.Json.Serialization;

namespace Infermedica.Net
{
    public class ConditionResponse
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        
        [JsonPropertyName("name")]
        public string Name { get; set; }
        
        [JsonPropertyName("common_name")]
        public string CommonName { get; set; }
        
        [JsonPropertyName("probability")]
        public double Probability { get; set; }
    }
}