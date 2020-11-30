using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Infermedica.Net
{
    public class Symptom
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
        
        [JsonPropertyName("common_name")]
        public string CommonName { get; set; }
        
        [JsonPropertyName("question")]
        public string Question { get; set; }
        
        [JsonPropertyName("sex_filter")]
        public string SexFilter { get; set; }
        
        [JsonPropertyName("category")]
        public string Category { get; set; }
        
        [JsonPropertyName("seriousness")]
        public string Seriousness { get; set; }

        [JsonPropertyName("extras")]
        public Extras Extras { get; set; }
        
        [JsonPropertyName("children")]
        public List<SymptomChild> Children { get; set; }
        
        [JsonPropertyName("image_url")]
        public object ImageUrl { get; set; }
        
        [JsonPropertyName("image_source")]
        public object ImageSource { get; set; }
        
        [JsonPropertyName("parent_id")]
        public object ParentId { get; set; }
        
        [JsonPropertyName("parent_relation")]
        public string ParentRelation { get; set; } 
    }
}