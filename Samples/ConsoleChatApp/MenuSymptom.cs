using System.Text.Json.Serialization;

namespace ConsoleChatApp
{
    public class MenuSymptom
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        
        [JsonPropertyName("choice_id")]
        public string ChoiceId { get; set; }
        
        [JsonPropertyName("initial")]
        public bool Initial { get; set; }
        
        [JsonPropertyName("related")]
        public bool Related { get; set; }
    }
}