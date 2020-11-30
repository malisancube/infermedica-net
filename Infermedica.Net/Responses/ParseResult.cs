using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Infermedica.Net
{
    public class ParseResult
    {
        [JsonPropertyName("mentions")]
        public List<Mention> Mentions { get; set; }
        
        [JsonPropertyName("obvious")]
        public bool Obvious { get; set; }
    }
}