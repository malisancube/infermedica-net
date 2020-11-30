using System;
using System.Threading.Tasks;
using Infermedica.Net;

namespace ConsoleChatApp
{
    public class WelcomeView : BaseView
    {
        public WelcomeView(PatientContext context, InferMedicaClient api) : base(context, api)
        {
        }

        public override void Render()
        {
            Console.WriteLine("Hi, Welcome to MyApp Medical Advisor.");
            Console.WriteLine();
        }

        public override async Task Execute()
        {
            _context.InterviewId = await Task.FromResult(_api.GetInterviewId());
        }
    }
}