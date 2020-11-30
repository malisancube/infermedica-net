using System;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Infermedica.Net;

namespace ConsoleChatApp
{
    public class DiagnosisView : BaseView
    {
        private ConsoleMenu<QuestionItem> _riskFactorCheckList;
        private ConsoleMenu<Choice> _choiceItems;
        private QuestionItem singleQuestionItem;

        public DiagnosisView(PatientContext context, InferMedicaClient api) : base(context, api)
        {
        }

        public override void Render()
        {
            Console.WriteLine();
        }

        public override async Task Execute()
        {
            var diagnosisRequest = JsonSerializer.Deserialize<DiagnosisRequest>(_context.Patient.ToDiagnosis());
            var response = await _api.GetDiagnosisAsync(_context.InterviewId, diagnosisRequest);
            
            if (response.Question != null 
                && response.Question.Items != null 
                && response.Question.Items.Any()
                && !response.Conditions.Any(p => p.Probability > .8))
            {
                AskQuestion(response.Question);
                Console.WriteLine();
            }
        }
        
        private void AskQuestion(Question question)
        {
            Console.WriteLine();
            if (question.Type == "group_single")
            {
                var items = question
                    .Items
                    .Select(i => new ConsoleMenuItem<QuestionItem>(i.Name, groupSingleCallback, i));
                _riskFactorCheckList = new ConsoleMenu<QuestionItem>(question.Text, items);
                _riskFactorCheckList.RunConsoleMenu();
            }
            
            if (question.Type == "single")
            {
                singleQuestionItem = question
                    .Items
                    .First();
                
                var choices =
                    singleQuestionItem
                    .Choices
                    .Select(i => new ConsoleMenuItem<Choice>(i.Label, singleCallback, i));
                _choiceItems = new ConsoleMenu<Choice>(question.Text, choices);
                _choiceItems.RunConsoleMenu();
            }
            
        }

        private void groupSingleCallback(QuestionItem questionItem)
        {
            _context.Patient.AddSymptom(new MenuSymptom
            {
                Id = questionItem.Id,
                ChoiceId = "present"
            });

            Execute().Wait();
        }
        
        private void singleCallback(Choice choice)
        {
            _context.Patient.AddSymptom(new MenuSymptom
            {
                Id = singleQuestionItem.Id,
                ChoiceId = choice.Id
            });

            Execute().Wait();
        }
    }
}