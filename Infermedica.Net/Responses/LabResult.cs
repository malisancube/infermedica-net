using Newtonsoft.Json;

namespace Infermedica.Net
{
    public class LabResult
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        
        [JsonProperty("type")]
        public string Type { get; set; }
    }
}