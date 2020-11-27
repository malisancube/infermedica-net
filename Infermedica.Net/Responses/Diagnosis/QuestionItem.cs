using System.Collections.Generic;
using Newtonsoft.Json;

namespace Infermedica.Net
{
    public class QuestionItem
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("choices")]
        public List<Choice> Choices { get; set; }
    }
}