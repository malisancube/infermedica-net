using Infermedica.Net;

namespace Dagala.ChatService
{
    public class InferMedicaSettings
    {
        public string AppName { get; set; } = KnownConstants.ApplicationName;
        
        public string AppKey { get; set; }
        
        public string AppId { get; set; }

        public string AppUrl { get; set; } = "https://api.infermedica.com/v2";
    }
}