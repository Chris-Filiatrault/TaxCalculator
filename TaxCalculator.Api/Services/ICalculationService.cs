namespace TaxCalculatorApi.Services
{
    using TaxCalculatorApi.Models;

    public interface ICalculationService
    {
        CalculationResultDto CalculateTax(decimal totalPackage, int payFrequency);
    }
}