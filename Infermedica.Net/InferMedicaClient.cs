using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Dagala.ChatService;
using Newtonsoft.Json;

namespace Infermedica.Net
{
    public class InferMedicaClient
    {
        private HttpClient _client { get; }

        public InferMedicaClient(HttpClient client, InferMedicaSettings settings)
        {
            client.BaseAddress = new Uri(settings.AppUrl);
            client.DefaultRequestHeaders.Add("App-Id", settings.AppId);
            client.DefaultRequestHeaders.Add("App-Key", settings.AppKey);
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("Dev-Mode", "true");
            client.DefaultRequestHeaders.Add("User-Agent", settings.AppName ?? KnownConstants.ApplicationName);
            client.BaseAddress = new Uri(settings.AppUrl);
            _client = client;
        }
        
        public string GetInterviewId()
        {
            return Guid
                .NewGuid()
                .ToString()
                .Replace("-", "")
                .Substring(0, 20);
        }
        
        #region Conditions
        public async Task<List<Condition>> GetConditionsAsync()
        {
            var response = await _client.GetAsync($"{_client.BaseAddress}/conditions");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            var conditions = JsonConvert.DeserializeObject<List<Condition>>(result);
            return conditions;
        }
        
        public async Task<Condition> GetConditionByIdAsync(string id)
        {
            var response = await _client.GetAsync($"{_client.BaseAddress}/conditions/{id}");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            var condition = JsonConvert.DeserializeObject<Condition>(result);
            return condition;
        }
        
        #endregion
        
        #region Diagnosis
        public async Task<DiagnosisResponse> GetDiagnosisAsync(string interviewId, DiagnosisRequest request)
        {
            // Ensure we are using the "Interview-Id" from the current request since the factory may cache the client object
            if (_client.DefaultRequestHeaders.Contains("Interview-Id"))
                _client.DefaultRequestHeaders.Remove("Interview-Id");
            _client.DefaultRequestHeaders.Add("Interview-Id", interviewId);
            
            var httpContent = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
            var response = await _client.PostAsync($"{_client.BaseAddress}/diagnosis", httpContent);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            var diagnosisResponse = JsonConvert.DeserializeObject<DiagnosisResponse>(result);
            return diagnosisResponse;
        }
        
        #endregion
        
        #region Explain
  
        public async Task<ExplainResponse> ExplainAsync(SuggestRequest request)
        {
            var httpContent = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
            var response = await _client.PostAsync($"{_client.BaseAddress}/explain", httpContent);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            var explainResponse = JsonConvert.DeserializeObject<ExplainResponse>(result);
            return explainResponse;
        }
        
        #endregion
        
        #region Symptoms
        public async Task<List<Symptom>> GetSymptomsAsync()
        {
             var response = await _client.GetAsync($"{_client.BaseAddress}/symptoms");
             response.EnsureSuccessStatusCode();
             var result = await response.Content.ReadAsStringAsync();
             var symptoms = JsonConvert.DeserializeObject<List<Symptom>>(result);
             return symptoms;
        }
        
        public async Task<Symptom> GetSymptomByIdAsync(string id)
        {
            var response = await _client.GetAsync($"{_client.BaseAddress}/symptoms/{id}");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            var symptom = JsonConvert.DeserializeObject<Symptom>(result);
            return symptom;
        }
        
        #endregion
        
        #region Info

        public async Task<ApiInfo> GetInfoAsync(string text)
        {
            var response = await _client.GetAsync($"{_client.BaseAddress}/info");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            var info = JsonConvert.DeserializeObject<ApiInfo>(result);
            return info;
        }
        
        #endregion
        
        #region Lab Tests
        
        public async Task<List<LabTest>> GetLabTestsAsync()
        {
            var response = await _client.GetAsync($"{_client.BaseAddress}/lab_tests");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            var labTests = JsonConvert.DeserializeObject<List<LabTest>>(result);
            return labTests;
        }
        
        public async Task<LabTest> GetLabTestByIdAsync(string id)
        {
            var response = await _client.GetAsync($"{_client.BaseAddress}/lab_tests/{id}");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            var labTest = JsonConvert.DeserializeObject<LabTest>(result);
            return labTest;
        }
        
        #endregion

        #region Lookup

        /// <summary>
        /// Returns a single observation matching given phrase
        /// </summary>
        /// <param name="phrase"></param>
        /// <param name="sex"></param>
        /// <returns></returns>
        public async Task<SearchResult> Lookupsync(string phrase, string sex)
        {
            var queryString = $"phrase={phrase}";
            if (sex != null) queryString = queryString + "&sex=" + sex;
            
            var builder = new UriBuilder($"{_client.BaseAddress}/lookup")
            {
                Query = queryString
            };
            
            var response = await _client.GetAsync(builder.Uri);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            var parseResult = JsonConvert.DeserializeObject<SearchResult>(result);
            return parseResult;
        }

        #endregion

        #region Parse

        public async Task<ParseResult> ParseAsync(string text)
        {
            var httpContent = new StringContent(JsonConvert.SerializeObject(new { text }), Encoding.UTF8, "application/json");
            var response = await _client.PostAsync($"{_client.BaseAddress}/parse", httpContent);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            var parseResult = JsonConvert.DeserializeObject<ParseResult>(result);
            return parseResult;
        }

        #endregion

        #region Risk Factors

        public async Task<List<RiskFactor>> GetRiskFactorsAsync()
        {
            var response = await _client.GetAsync($"{_client.BaseAddress}/risk_factors");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            var riskFactors = JsonConvert.DeserializeObject<List<RiskFactor>>(result);
            return riskFactors;
        }
        
        public async Task<List<RiskFactor>> GetRiskFactorByIdAsync(string id)
        {
            var response = await _client.GetAsync($"{_client.BaseAddress}/risk_factors/{id}");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            var riskFactors = JsonConvert.DeserializeObject<List<RiskFactor>>(result);
            return riskFactors;
        }

        #endregion

        #region Search

        // Returns list of observations matching the given phrase
        public async Task<List<SearchResult>> SearchAsync(string phrase, string sex, int? maxResults, string[] types)
        {
            var queryString = $"phrase={phrase}";
            if (maxResults != null) queryString = queryString + "&max_results=" + maxResults;
            if (sex != null) queryString = queryString + "&sex=" + sex;
            if (types != null && types.Any()) queryString = queryString + "&type=" + string.Join("&type=", types);
            
            var builder = new UriBuilder($"{_client.BaseAddress}/search")
            {
                Query = queryString
            };
            
            var response = await _client.GetAsync(builder.Uri);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            var parseResult = JsonConvert.DeserializeObject<List<SearchResult>>(result);
            return parseResult;
        }

        #endregion

        #region Suggest

        public async Task<List<SuggestResponse>> GetSuggestedSymptomsAsync(SuggestRequest suggestRequest)
        {
            var httpContent = new StringContent(JsonConvert.SerializeObject(suggestRequest), Encoding.UTF8, "application/json");
            var response = await _client.PostAsync($"{_client.BaseAddress}/suggest", httpContent);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            var suggestedSymptoms = JsonConvert.DeserializeObject<List<SuggestResponse>>(result);
            return suggestedSymptoms;
        }

        #endregion
        
        #region Triage
        public async Task<TriageResponse> GetTriageAsync(TriageRequest request)
        {
            var httpContent = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
            var response = await _client.PostAsync($"{_client.BaseAddress}/triage", httpContent);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            var triageResponse = JsonConvert.DeserializeObject<TriageResponse>(result);
            return triageResponse;
        }
        
        #endregion
    }
}