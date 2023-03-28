    namespace TaxCalculatorUI.Services
{
    using System.Net.Http;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;
    using TaxCalculatorUI.Models;
    using Newtonsoft.Json;
    using System;
    using System.Threading.Tasks;

    public class TaxCalculatorService
    {
        private readonly HttpClient client;
        private readonly IConfiguration configuration;
        private readonly ILogger<TaxCalculatorService> log;

        public TaxCalculatorService(
            HttpClient client,
            IConfiguration configuration,
            ILogger<TaxCalculatorService> log)
        {
            this.configuration = configuration;
            this.log = log;
            this.client = client;
  
        }

        public async Task<ResultModel> CalculateTax(decimal totalPackage, int payFrequency)
        {
            var baseUrl = configuration.GetValue<string>("TaxCalculatorApiUrl");
            var query = $"CalculateTax?totalPackage={totalPackage}&payFrequency={payFrequency}";
            var requestString = baseUrl + query;

            string responseContent;
            try
            {
                var httpResponse = await client.GetAsync(requestString);
                responseContent = await httpResponse.Content.ReadAsStringAsync();
            }
            catch (Exception exception)
            {
                log.LogInformation(exception, "Failed to call Tax Calculator API with query {Query}", query);
                throw;
            }

            var result = JsonConvert.DeserializeObject<ResultModel>(responseContent);

            return result;
        }
    }
}


