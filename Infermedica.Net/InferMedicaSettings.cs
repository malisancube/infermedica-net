using Infermedica.Net;

namespace Infermedica.Net
{
    public class InferMedicaSettings
    {
        public string AppName { get; set; } = KnownConstants.ApplicationName;
        
        public string AppKey { get; set; }
        
        public string AppId { get; set; }

        public string AppUrl { get; set; } = "https://api.infermedica.com/v2";

        public bool DevMode { get; set; } = true;
    }
}