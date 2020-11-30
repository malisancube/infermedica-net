using System.Text.Json.Serialization;

namespace Infermedica.Net
{
    public class LabResult
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        
        [JsonPropertyName("type")]
        public string Type { get; set; }
    }
}