using System.Collections.Generic;
using Newtonsoft.Json;

namespace Infermedica.Net
{
    public class Symptom
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("common_name")]
        public string CommonName { get; set; }
        
        [JsonProperty("question")]
        public string Question { get; set; }
        
        [JsonProperty("sex_filter")]
        public string SexFilter { get; set; }
        
        [JsonProperty("category")]
        public string Category { get; set; }
        
        [JsonProperty("seriousness")]
        public string Seriousness { get; set; }

        [JsonProperty("extras")]
        public Extras Extras { get; set; }
        
        [JsonProperty("children")]
        public List<SymptomChild> Children { get; set; }
        
        [JsonProperty("image_url")]
        public object ImageUrl { get; set; }
        
        [JsonProperty("image_source")]
        public object ImageSource { get; set; }
        
        [JsonProperty("parent_id")]
        public object ParentId { get; set; }
        
        [JsonProperty("parent_relation")]
        public string ParentRelation { get; set; } 
    }
}