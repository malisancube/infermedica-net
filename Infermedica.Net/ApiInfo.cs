using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Infermedica.Net
{
    public class ApiInfo
    {
        [JsonPropertyName("updated_at")]
        public DateTime UpdatedAt { get; set; }
        
        [JsonPropertyName("conditions_count")]
        public int ConditionsCount { get; set; }
        
        [JsonPropertyName("symptoms_count")]
        public int SymptomsCount { get; set; }
        
        [JsonPropertyName("risk_factors_count")]
        public int RiskFactorsCount { get; set; }
        
        [JsonPropertyName("lab_tests_count")]
        public int LabTestsCount { get; set; }
    }
}