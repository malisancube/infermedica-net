using Newtonsoft.Json;

namespace Infermedica.Net
{
    public class SearchResult
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        
        [JsonProperty("label")]
        public string Label { get; set; }
    }
}