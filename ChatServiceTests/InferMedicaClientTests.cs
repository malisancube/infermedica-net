using System;
using System.Net.Http;
using Dagala.ChatService;
using Infermedica.Net;
using Xunit;

namespace ChatServiceTests
{
    public class InferMedicaClientTests
    {
        private HttpClient client;
        private InferMedicaClient inferMedicaClient;

        public InferMedicaClientTests()
        {
            Initialise();
        }

        private void Initialise()
        {
            client = new HttpClient();
            var settings = new InferMedicaSettings
            {
                AppUrl = "https://api.infermedica.com/v2",
                AppId = "XXXX",
                AppKey = "XXXXXXX"
            };
            inferMedicaClient = new InferMedicaClient(client, settings);
        }

        [Fact]
        public void SymptomTests()
        {
            Assert.NotNull(inferMedicaClient);
        }
        
        [Fact]
        public void ParseTests()
        {
            var response = inferMedicaClient.ParseAsync("i feel smoach pain but no couoghing today").Result;
            Assert.NotNull(response);
            Assert.True(response.Mentions.Count > 0);
        }
    }
}