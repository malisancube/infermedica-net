using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Infermedica.Net;

namespace ConsoleChatApp
{
    class Program
    {
        private InferMedicaClient _inferMedicaClient;

        static async Task Main(string[] args)
        {
            var program = new Program();
            await program.RunAsync();
        }

        private async Task RunAsync()
        {
            Console.Clear();
            Initialize();
            
            using (var context = new PatientContext())
            {
                foreach (var view in Views(context, _inferMedicaClient))
                {
                    view.Render();
                    await view.Execute();
                }
                Console.WriteLine("------");
            }
        }

        private void Initialize()
        {
            var client = new HttpClient();
            var settings = new InferMedicaSettings
            {
                AppName = "MyApp",
                AppUrl = "https://api.infermedica.com/v2",
                AppId = "xxx",
                AppKey = "xxxxxx",
                DevMode = true
            };
            _inferMedicaClient = new InferMedicaClient(client, settings);
        }

        private IEnumerable<BaseView> Views(PatientContext context, InferMedicaClient api)
        {
            yield return new WelcomeView(context, api);
            yield return new ParseView(context, api);
            yield return new DemographicsView(context, api);
            yield return new SuggestView(context, api);
            yield return new CommonRisksView(context, api);
            yield return new LocationRisksView(context, api);
            yield return new DiagnosisView(context, api);
            yield return new SummaryView(context, api);
        }
    }
}