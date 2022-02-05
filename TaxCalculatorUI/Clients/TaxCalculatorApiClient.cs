using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using TaxCalculatorUI.Models;
using Newtonsoft.Json;

namespace TaxCalculatorUI.Clients
{
    public class TaxCalculatorApiClient
    {
        private HttpClient client;
        private IConfiguration configuration;
        private ILogger<TaxCalculatorApiClient> logger;

        public TaxCalculatorApiClient(
            HttpClient client, IConfiguration configuration,
            ILogger<TaxCalculatorApiClient> logger)
        {
            this.client = client;
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/json"));
            this.configuration = configuration;
            this.logger = logger;
        }

        // TODO: Make API call async
        public ResultDto CallTaxCalculatorApi(double totalPackage, int payFrequency)
        {
            var baseUrl = configuration.GetSection("TaxCalculatorApiUrl").Value;

            var query = $"CalculateTax?totalPackage={totalPackage}&payFrequency={payFrequency}";

            var requestString = baseUrl + query;
            
            var httpResponse = client.GetAsync(requestString).Result;

            string result = httpResponse.Content.ReadAsStringAsync().Result;

            // TODO: Exception handling
            var resultToReturn = JsonConvert.DeserializeObject<ResultDto>(result);
            return resultToReturn;
        }
    }
}


