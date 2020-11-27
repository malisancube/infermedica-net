using Newtonsoft.Json;

namespace Infermedica.Net
{
    public class RiskFactor
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

        [JsonProperty("extras")] 
        public Extras Extras { get; set; }

        [JsonProperty("image_url")] 
        public string ImageUrl { get; set; }

        [JsonProperty("image_source")] 
        public string ImageSource { get; set; }
    }
}