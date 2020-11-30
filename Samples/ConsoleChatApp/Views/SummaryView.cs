using System;
using System.Linq;
using System.Threading.Tasks;
using Infermedica.Net;
using Newtonsoft.Json;

namespace ConsoleChatApp
{
    public class SummaryView : BaseView
    {
        
        public SummaryView(PatientContext context, InferMedicaClient api) : base(context, api)
        {
        }

        public override void Render()
        {
            Console.WriteLine("The following is the summary of what could be the problem. Please verify with doctor.");
            Console.WriteLine();
        }

        public override async Task Execute()
        {
            var diagnosisRequest = JsonConvert.DeserializeObject<DiagnosisRequest>(_context.Patient.ToDiagnosis());
            var response = await _api.GetDiagnosisAsync(_context.InterviewId, diagnosisRequest);
            
            foreach (var d in response.Conditions.Select(t => new { t.Name, t.Probability}))
            {
                Console.WriteLine("{0} : {1}", d.Name, d.Probability);
            }
        }
    }
}