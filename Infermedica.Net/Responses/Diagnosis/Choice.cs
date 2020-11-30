using System.Text.Json.Serialization;

namespace Infermedica.Net
{
    public class Choice
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        
        [JsonPropertyName("label")]
        public string Label { get; set; }
    }
}