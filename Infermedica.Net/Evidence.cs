using Newtonsoft.Json;

namespace Infermedica.Net
{
    public class Evidence
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        
        /// <summary>
        /// Accepts present, absent or unknown 
        /// </summary>
        [JsonProperty("choice_id")]
        public string ChoiceId { get; set; }
        
        [JsonProperty("initial")]
        public bool? Initial { get; set; }

        [JsonProperty("observed_at")]
        public string ObservedAt { get; set; }
    }
}