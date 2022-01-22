using TaxCalculatorApi.Models;

namespace TaxCalculatorApi.Services
{
    public interface ICalculationService
    {
        double CalculateTax(double income);
    }
}