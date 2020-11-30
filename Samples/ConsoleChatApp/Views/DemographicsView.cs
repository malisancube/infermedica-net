using System;
using System.Linq;
using System.Threading.Tasks;
using Infermedica.Net;

namespace ConsoleChatApp
{
    public class DemographicsView : BaseView
    {
        private ConsoleMenu<string> _sexMenu;

        public DemographicsView(PatientContext context, InferMedicaClient api) : base(context, api)
        {
        }

        public override void Render()
        {
            var items = new []
            {
                "female", 
                "male"
            }.Select(i => new ConsoleMenuItem<string>(i, sexCallback, i));
            
            _sexMenu = new ConsoleMenu<string>("Select Gender:", items);
        }

        public override async Task Execute()
        {
            _sexMenu.RunConsoleMenu();
            Console.WriteLine();

            _context.Patient.Age = ConsoleInput.GetNumber("Whats your age?");
            Console.WriteLine();
            
            await Task.FromResult(0);
        }
        
        private void sexCallback(string selectedSex)
        {
            _context.Patient.Sex = selectedSex;
        }
    }
}