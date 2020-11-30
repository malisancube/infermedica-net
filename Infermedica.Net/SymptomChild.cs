using System.Text.Json.Serialization;

namespace Infermedica.Net
{
    public class SymptomChild
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        
        [JsonPropertyName("parent_relation")]
        public string ParentRelation { get; set; }
    }
}