using System.Text.Json.Serialization;

namespace Infermedica.Net
{
    public class RiskFactor
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

        [JsonPropertyName("extras")] 
        public Extras Extras { get; set; }

        [JsonPropertyName("image_url")] 
        public string ImageUrl { get; set; }

        [JsonPropertyName("image_source")] 
        public string ImageSource { get; set; }
    }
}