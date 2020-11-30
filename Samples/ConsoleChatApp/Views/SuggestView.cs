using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Infermedica.Net;

namespace ConsoleChatApp
{
    public class SuggestView : BaseView
    {
        private ConsoleCheckList<SuggestResponse> _symptomMenu;
        private List<SuggestResponse> symptoms;

        public SuggestView(PatientContext context, InferMedicaClient api) : base(context, api)
        {
        }

        public override void Render()
        {
            Console.WriteLine();
        }

        public override async Task Execute()
        {
            var suggestRequest = JsonSerializer.Deserialize<SuggestRequest>(_context.Patient.ToDiagnosis());
            symptoms = await _api.GetSuggestedSymptomsAsync(suggestRequest);
            var items = symptoms.Select(i => new ConsoleCheckListItem<SuggestResponse>(i.CommonName, symptomCallback, i));
            
            _symptomMenu = new ConsoleCheckList<SuggestResponse>("Any of the following symptoms?", items);
            
            _symptomMenu.RunConsoleCheckList();
            Console.WriteLine();
        }
        
        private void symptomCallback(SuggestResponse symptom, int[] selectedItems)
        {
            for (var i = 0; i < symptoms.Count; i++)
            {
                if (selectedItems.Contains(i))
                {
                    _context.Patient.AddSymptom(new MenuSymptom
                    {
                        Id = symptom.Id,
                        ChoiceId = "present"
                    });
                }
                else
                {   
                    _context.Patient.AddSymptom(new MenuSymptom
                    {
                        Id = symptom.Id,
                        ChoiceId = "absent"
                    });
                }
            }
        }
    }
}