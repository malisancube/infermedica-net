using System.Collections.Generic;
using Newtonsoft.Json;

namespace Infermedica.Net
{
    public class ExplainResponse
    {
        [JsonProperty("supporting_evidence")]
        public List<SupportingEvidence> SupportingEvidence { get; set; }
        
        [JsonProperty("conflicting_evidence")]
        public List<ConflictingEvidence> ConflictingEvidence { get; set; }
        
        [JsonProperty("unconfirmed_evidence")]
        public List<UnconfirmedEvidence> UnconfirmedEvidence { get; set; }
    }
}