using System.Collections.Generic;
using Newtonsoft.Json;

namespace Infermedica.Net
{
    public class ParseResult
    {
        [JsonProperty("mentions")]
        public List<Mention> Mentions { get; set; }
        
        [JsonProperty("obvious")]
        public bool Obvious { get; set; }
    }
}