using Newtonsoft.Json;

namespace Infermedica.Net
{
    public class Mention
    {
        [JsonProperty("common_name")]
        public string CommonName { get; set; }
        
        [JsonProperty("orth")]
        public string Orth { get; set; }
        
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("type")]
        public string Type { get; set; }
        
        [JsonProperty("choice_id")]
        public string ChoiceId { get; set; }
        
        [JsonProperty("id")]
        public string Id { get; set; }
    }
}