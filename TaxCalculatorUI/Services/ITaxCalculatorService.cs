namespace TaxCalculatorUI.Services
{
    using System.Threading.Tasks;
    using TaxCalculatorUI.Models;

    public interface ITaxCalculatorService
    {
        Task<ResultModel> CalculateTax(decimal totalPackage, int payFrequency);
    }
}