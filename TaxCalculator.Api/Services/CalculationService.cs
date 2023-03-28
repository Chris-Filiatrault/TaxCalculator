namespace TaxCalculatorApi.Services
{
    using System;
    using TaxCalculatorApi.Models;

    public class CalculationService : ICalculationService
    {
        public decimal CalculateSuperannuation(decimal totalPackage)
        {
            return decimal.Round(totalPackage - totalPackage / (decimal)1.095, 2, MidpointRounding.ToPositiveInfinity);
        }

        public decimal CalculateTaxableIncome(decimal totalPackage, decimal superannuation)
        {
            return Math.Round(totalPackage - superannuation, 2);
        }

        public decimal CalculateMedicareLevy(decimal deductionTaxableIncome, int tier1 = 21335, int tier2 = 26668)
        {
            if (deductionTaxableIncome <= tier1)
            {
                return 0;
            }
            else if (deductionTaxableIncome >= (tier1 + 1) & deductionTaxableIncome <= tier2)
            {
                return Math.Ceiling((deductionTaxableIncome - tier1) * (decimal)0.1);
            }
            else
            {
                return Math.Ceiling(deductionTaxableIncome * (decimal)0.02);
            }
        }

        public decimal CalculateBudgetRepairLevy(decimal deductionTaxableIncome, int tier1 = 180000)
        {
            if (deductionTaxableIncome <= tier1)
            {
                return 0;
            }
            else
            {
                return Math.Ceiling((deductionTaxableIncome - tier1) * (decimal)0.02);
            }
        }

        public decimal CalculateIncomeTax(
            decimal deductionTaxableIncome,
            int tier1 = 18200,
            int tier2 = 37000,
            int tier3 = 87000,
            int tier4 = 180000
        )
        {
            if (deductionTaxableIncome <= tier1)
            {
                return 0;
            }
            else if (deductionTaxableIncome >= (tier1 + 1) & deductionTaxableIncome <= tier2)
            {
                return Math.Ceiling((deductionTaxableIncome - tier1) * (decimal)0.19);
            }
            else if (deductionTaxableIncome >= (tier2 + 1) & deductionTaxableIncome <= tier3)
            {
                return 3572 + Math.Ceiling((deductionTaxableIncome - tier2) * (decimal)0.325);
            }
            else if (deductionTaxableIncome >= tier3 & deductionTaxableIncome <= tier4)
            {
                return 19822 + Math.Ceiling((deductionTaxableIncome - tier3) * (decimal)0.37);
            }
            else
            {
                return Math.Ceiling(54000 + ((deductionTaxableIncome - tier4) * (decimal)0.47));
            }
        }

        public CalculationResultDto CalculateTax(decimal totalPackage, int payFrequency)
        {
            CalculationResultDto calculationResult = new()
            {
                TotalPackage = totalPackage,
                PayFrequency = payFrequency
            };

            calculationResult.Superannuation = CalculateSuperannuation(calculationResult.TotalPackage);
            
            calculationResult.TaxableIncome = CalculateTaxableIncome(calculationResult.TotalPackage, calculationResult.Superannuation);
            
            calculationResult.DeductionTaxableIncome = Math.Floor(calculationResult.TaxableIncome);
            
            calculationResult.MedicareLevy = CalculateMedicareLevy(calculationResult.DeductionTaxableIncome);
            
            calculationResult.BudgetRepairLevy = CalculateBudgetRepairLevy(calculationResult.DeductionTaxableIncome);
            
            calculationResult.IncomeTax = CalculateIncomeTax(calculationResult.DeductionTaxableIncome);
            
            calculationResult.Deductions = calculationResult.MedicareLevy + calculationResult.BudgetRepairLevy + calculationResult.IncomeTax;

            calculationResult.NetIncome = decimal.Round(calculationResult.TotalPackage - calculationResult.Superannuation - calculationResult.Deductions, 2, MidpointRounding.ToPositiveInfinity);

            calculationResult.PayPacket = decimal.Round(calculationResult.NetIncome / calculationResult.PayFrequency, 2, MidpointRounding.ToPositiveInfinity);

            return calculationResult;
        }
    }
}
