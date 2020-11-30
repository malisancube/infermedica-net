
using System.Text.Json.Serialization;

namespace Infermedica.Net
{
    public class Evidence
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        
        /// <summary>
        /// Accepts present, absent or unknown 
        /// </summary>
        [JsonPropertyName("choice_id")]
        public string ChoiceId { get; set; }
        
        [JsonPropertyName("initial")]
        public bool? Initial { get; set; }

        [JsonPropertyName("observed_at")]
        public string ObservedAt { get; set; }
    }
}