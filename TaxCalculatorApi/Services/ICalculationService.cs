using TaxCalculatorApi.Models;

namespace TaxCalculatorApi.Services
{
    public interface ICalculationService
    {
        CalculationResultDto CalculateTax(int income);
    }
}