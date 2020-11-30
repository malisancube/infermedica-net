using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleChatApp
{
    public class PatientContext : IDisposable
    {
        public Guid Id { get; set; }
        public string InterviewId { get; set; }
        
        public Patient Patient { get; set; }
        
        public List<string> CommonRiskFactors { get; set; }
        
        public List<string> LocationRiskFactors { get; set; }

        public PatientContext()
        {
            Patient = new Patient();
            CommonRiskFactors = new List<string>();
            LocationRiskFactors = new List<string>();
        }

        public void Dispose()
        {
            Patient = null;
        }
    }
}