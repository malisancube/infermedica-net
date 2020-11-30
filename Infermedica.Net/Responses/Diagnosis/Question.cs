using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Infermedica.Net
{
    public class Question
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }
        
        [JsonPropertyName("text")]
        public string Text { get; set; }
        
        [JsonPropertyName("items")]
        public List<QuestionItem> Items { get; set; }
        
        [JsonPropertyName("extras")]
        public Extras Extras { get; set; }
    }
}