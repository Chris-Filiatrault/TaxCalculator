using System;
using TaxCalculatorApi.Functions;
using TaxCalculatorApi.Models;

namespace TaxCalculatorApi.Services
{
    public class CalculationService : ICalculationService
    {
        public CalculationResultDto CalculateTax(double totalPackage, int payFrequency)
        {
            CalculationResultDto calculationResult = new();

            calculationResult.TotalPackage = totalPackage;
            
            calculationResult.PayFrequency = payFrequency;
            
            calculationResult.Superannuation = Calculations.CalculateSuperannuation(calculationResult.TotalPackage);
            
            calculationResult.TaxableIncome = Calculations.CalculateTaxableIncome(calculationResult.TotalPackage, calculationResult.Superannuation);
            
            calculationResult.DeductionTaxableIncome = Math.Floor(calculationResult.TaxableIncome);
            
            calculationResult.MedicareLevy = Calculations.CalculateMedicareLevy(calculationResult.DeductionTaxableIncome);
            
            calculationResult.BudgetRepairLevy = Calculations.CalculateBudgetRepairLevy(calculationResult.DeductionTaxableIncome);
            
            calculationResult.IncomeTax = Calculations.CalculateIncomeTax(calculationResult.DeductionTaxableIncome);
            
            calculationResult.Deductions = calculationResult.MedicareLevy + calculationResult.BudgetRepairLevy + calculationResult.IncomeTax;
            
            calculationResult.NetIncome = Utilities.RoundUp(calculationResult.TotalPackage - calculationResult.Superannuation - calculationResult.Deductions, 2);
            
            calculationResult.PayPacket = Utilities.RoundUp(calculationResult.NetIncome / calculationResult.PayFrequency, 2);

            return calculationResult;
        }
    }
}
