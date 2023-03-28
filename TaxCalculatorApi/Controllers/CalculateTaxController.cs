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
        private readonly ILogger<CalculateTaxController> logger;
        private readonly ICalculationService calculationService;

        public CalculateTaxController(
            ILogger<CalculateTaxController> logger,
            ICalculationService calculationService
            )
        {
            this.logger = logger;
            this.calculationService = calculationService;
        }

        [HttpGet]
        public CalculationResultDto Get(decimal totalPackage, int payFrequency)
        {
            var result = calculationService.CalculateTax(totalPackage, payFrequency);
            return result;
        }
    }
}
