using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TaxCalculatorApi.Models;
using TaxCalculatorApi.Services;

namespace TaxCalculatorApi.Controllers
{
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
        public CalculationResultDto Get(double totalPackage, int payFrequency)
        {
            var result = calculationService.CalculateTax(totalPackage, payFrequency);
            return result;
        }
    }
}
