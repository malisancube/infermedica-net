using System.Collections.Generic;
using Infermedica.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ConsoleChatApp
{
    public class Patient
    {
        private List<MenuSymptom> _symptoms = new List<MenuSymptom>(); 
        
        public string Sex { get; set; }
        public int Age { get; set; }

        public void AddSymptom(MenuSymptom symptom)
        {
            _symptoms.Add(symptom);
        }

        public void RemoveSymptom(MenuSymptom symptom)
        {
            _symptoms.Remove(symptom);
        }

        public void Reset()
        {
            _symptoms.Clear();
        }

        public SuggestRequest Symptoms { get; set; }

        public string ToDiagnosis()
        {
            dynamic patient = new JObject();
            patient.sex = this.Sex;
            patient.age = this.Age;
            patient.evidence = new JArray();
            
            foreach (var item in _symptoms)
            {
                dynamic evidence = new JObject();
                evidence.id = item.Id;
                evidence.choice_id = item.ChoiceId;
                
                if (item.Initial) evidence.initial = true;
                if (item.Related) evidence.related = true;
                patient.evidence.Add(evidence); 
            }
            return patient.ToString();
        }
    }

    public class MenuSymptom
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        
        [JsonProperty("choice_id")]
        public string ChoiceId { get; set; }
        
        [JsonProperty("initial")]
        public bool Initial { get; set; }
        
        [JsonProperty("related")]
        public bool Related { get; set; }
    }
}