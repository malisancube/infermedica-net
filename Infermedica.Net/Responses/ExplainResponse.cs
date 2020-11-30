using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Infermedica.Net
{
    public class ExplainResponse
    {
        [JsonPropertyName("supporting_evidence")]
        public List<SupportingEvidence> SupportingEvidence { get; set; }
        
        [JsonPropertyName("conflicting_evidence")]
        public List<ConflictingEvidence> ConflictingEvidence { get; set; }
        
        [JsonPropertyName("unconfirmed_evidence")]
        public List<UnconfirmedEvidence> UnconfirmedEvidence { get; set; }
    }
}