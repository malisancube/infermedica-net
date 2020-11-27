using Newtonsoft.Json;

namespace Infermedica.Net
{
    public class SymptomChild
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        
        [JsonProperty("parent_relation")]
        public string ParentRelation { get; set; }
    }
}