using System;
using TaxCalculatorApi.Functions;
using TaxCalculatorApi.Models;

namespace TaxCalculatorApi.Services
{
    public class CalculationService : ICalculationService
    {
        public CalculationResultDto CalculateTax(int totalPackage)
        {
            CalculationResultDto calculationResult = new();

            calculationResult.TotalPackage = totalPackage;
            calculationResult.Superannuation = Calculations.CalculateSuperannuation(calculationResult.TotalPackage);
            calculationResult.TaxableIncome = Calculations.CalculateTaxableIncome(calculationResult.TotalPackage, calculationResult.Superannuation);
            calculationResult.DeductionTaxableIncome = Math.Floor(calculationResult.TaxableIncome);
            calculationResult.MedicareLevy = Calculations.CalculateMedicareLevy(calculationResult.DeductionTaxableIncome);
            calculationResult.BudgetRepairLevy = Calculations.CalculateBudgetRepairLevy(calculationResult.DeductionTaxableIncome);
            calculationResult.IncomeTax = Calculations.CalculateIncomeTax(calculationResult.DeductionTaxableIncome);
            calculationResult.Deductions = calculationResult.MedicareLevy + calculationResult.BudgetRepairLevy + calculationResult.IncomeTax;
            calculationResult.NetIncome = calculationResult.TotalPackage - calculationResult.Superannuation - calculationResult.Deductions;

            // TODO: Handle unhandled exception after introducing calculationResult.PayFrequency
            //calculationResult.PayPacket = Utilities.RoundUp(calculationResult.NetIncome / calculationResult.PayFrequency, 2);

            return calculationResult;
        }
    }
}
