using System;
using System.Linq;
using System.Threading.Tasks;
using Infermedica.Net;

namespace ConsoleChatApp
{
    public class ParseView : BaseView
    {
        public ParseView(PatientContext context, InferMedicaClient api) : base(context, api)
        {
        }

        public override void Render()
        {
            Console.WriteLine("What seems to be your main complaint today?");
        }

        public override async Task Execute()
        {
            var input = Console.ReadLine();
            var anySymptom = false;
            while (!anySymptom)
            {
                var response = await _api.ParseAsync(input);

                anySymptom = response.Mentions.Any();
                var firstSay =  anySymptom ? "OK, you have the following:" : "Could not deduce the main problem, may you rephrase it?";
                Console.WriteLine(firstSay);
                response.Mentions.ForEach(i =>
                {
                    Console.WriteLine($" Identified  {i.CommonName}");
                    
                    _context.Patient.AddSymptom(new MenuSymptom
                    {
                        Id = i.Id,
                        ChoiceId = "present"
                    });
                });
                Console.WriteLine();
            } 
        }
    }
}