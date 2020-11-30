using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infermedica.Net;

namespace ConsoleChatApp
{
    public class LocationRisksView : BaseView
    {
        private List<RiskFactor> riskFactors;
        private ConsoleCheckList<RiskFactor> _riskFactorCheckList;

        public LocationRisksView(PatientContext context, InferMedicaClient api) : base(context, api)
        {
        }

        public override void Render()
        {
            _context.LocationRiskFactors = new List<string> {"p_15", "p_20", "p_21", "p_16", "p_17", "p_18", "p_14", "p_19", "p_22", "p_13"};
            Console.WriteLine();
        }

        public override async Task Execute()
        {
            riskFactors = await _api.GetRiskFactorsAsync();

            var items = riskFactors
                .Where(i => _context.LocationRiskFactors.Contains(i.Id))
                .Select(i => new ConsoleCheckListItem<RiskFactor>(i.CommonName, riskFactorCallback, i));
            _riskFactorCheckList = new ConsoleCheckList<RiskFactor>("Please select where you live or have recently traveled to.", items);
            _riskFactorCheckList.RunConsoleCheckList();
        }
        
        private void riskFactorCallback(RiskFactor symptom, int[] selectedItems)
        {
            for (var i = 0; i < riskFactors.Count; i++)
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