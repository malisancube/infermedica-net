using System.Collections.Generic;
using Newtonsoft.Json;

namespace Infermedica.Net
{
    public class Question
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        
        [JsonProperty("text")]
        public string Text { get; set; }
        
        [JsonProperty("items")]
        public List<QuestionItem> Items { get; set; }
        
        [JsonProperty("extras")]
        public Extras Extras { get; set; }
    }
}