using System.Text.Json.Serialization;

namespace Infermedica.Net
{
    public class UnconfirmedEvidence
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        
        [JsonPropertyName("name")]
        public string Name { get; set; }
        
        [JsonPropertyName("common_name")]
        public string CommonName { get; set; }
    }
}