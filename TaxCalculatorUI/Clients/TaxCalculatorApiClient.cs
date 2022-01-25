using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

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

        public string CallTaxCalculatorApi(int number)
        {
            var baseUrl = configuration.GetSection("TaxCalculatorApiUrl").Value;

            var requestString = baseUrl + $"?income={number}";
            
            var response = client.GetAsync(requestString).Result;

            string result = response.Content.ReadAsStringAsync().Result;
            
            if (response.IsSuccessStatusCode)
            {
                logger.LogInformation("Normal result: " + result);
            }
            else
            {
                logger.LogError("Error: " + result);
            }

            response.EnsureSuccessStatusCode();
            return result;
        }
    }
}


