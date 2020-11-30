using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infermedica.Net;

namespace ConsoleChatApp
{
    public class CommonRisksView : BaseView
    {
        private List<RiskFactor> riskFactors;
        private ConsoleCheckList<RiskFactor> _riskFactorCheckList;

        public CommonRisksView(PatientContext context, InferMedicaClient api) : base(context, api)
        {
        }

        public override void Render()
        {
            _context.CommonRiskFactors.AddRange(new [] {"p_7", "p_28", "p_10", "p_9", "p_147", "p_8"});
            
            // p_11 is postmenopausal - we show this factor only for women after 39 yo
            if (_context.Patient.Sex == "female" && _context.Patient.Age > 39) {
                _context.CommonRiskFactors.Add("p_11");
            }
            Console.WriteLine();
        }

        public override async Task Execute()
        {
            riskFactors = await _api.GetRiskFactorsAsync();

            var items = riskFactors
                .Where(i => _context.CommonRiskFactors.Contains(i.Id))
                .Select(i => new ConsoleCheckListItem<RiskFactor>(i.CommonName, riskFactorCallback, i));
            
            _riskFactorCheckList = new ConsoleCheckList<RiskFactor>("Please check all that apply to you.", items);
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