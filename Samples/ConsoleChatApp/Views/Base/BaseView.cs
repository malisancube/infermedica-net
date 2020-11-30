using System.Threading.Tasks;
using Infermedica.Net;

namespace ConsoleChatApp
{
    public abstract class BaseView
    {
        protected readonly PatientContext _context;
        protected readonly InferMedicaClient _api;

        public BaseView(PatientContext context, InferMedicaClient api)
        {
            _context = context;
            _api = api;
        }

        public abstract void Render();

        public abstract Task Execute();
    }
}