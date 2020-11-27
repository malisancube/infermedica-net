using System;
using Newtonsoft.Json;

namespace Infermedica.Net
{
    public class ApiInfo
    {
        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }
        
        [JsonProperty("conditions_count")]
        public int ConditionsCount { get; set; }
        
        [JsonProperty("symptoms_count")]
        public int SymptomsCount { get; set; }
        
        [JsonProperty("risk_factors_count")]
        public int RiskFactorsCount { get; set; }
        
        [JsonProperty("lab_tests_count")]
        public int LabTestsCount { get; set; }
    }
}