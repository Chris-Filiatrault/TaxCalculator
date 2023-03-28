namespace TaxCalculatorApi.Services
{
    using TaxCalculatorApi.Models;

    public interface ICalculationService
    {
        CalculationResultDto CalculateTax(double totalPackage, int payFrequency);
    }
}