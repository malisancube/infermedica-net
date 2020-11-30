using System.Text.Json.Serialization;

namespace Infermedica.Net
{
    public class Mention
    {
        [JsonPropertyName("common_name")]
        public string CommonName { get; set; }
        
        [JsonPropertyName("orth")]
        public string Orth { get; set; }
        
        [JsonPropertyName("name")]
        public string Name { get; set; }
        
        [JsonPropertyName("type")]
        public string Type { get; set; }
        
        [JsonPropertyName("choice_id")]
        public string ChoiceId { get; set; }
        
        [JsonPropertyName("id")]
        public string Id { get; set; }
    }
}