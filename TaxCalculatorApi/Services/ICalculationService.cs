using TaxCalculatorApi.Models;

namespace TaxCalculatorApi.Services
{
    public interface ICalculationService
    {
        CalculationResultDto CalculateTax(double totalPackage, int payFrequency);
    }
}