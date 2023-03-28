namespace TaxCalculatorApi.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using TaxCalculatorApi.Models;
    using TaxCalculatorApi.Services;

    [ApiController]
    [Route("[controller]")]
    public class CalculateTaxController : Controller
    {
        private readonly ILogger<CalculateTaxController> log;
        private readonly ICalculationService calculationService;

        public CalculateTaxController(ILogger<CalculateTaxController> log, ICalculationService calculationService)
        {
            this.log = log;
            this.calculationService = calculationService;
        }

        [HttpGet]
        public CalculationResultDto Get(decimal totalPackage, int payFrequency)
        {
            log.LogInformation("Calling Calculation Service with totalPackage {TotalPackage} and payFrequency {PayFrequency}", totalPackage, payFrequency);
            var result = calculationService.CalculateTax(totalPackage, payFrequency);
            return result;
        }
    }
}
