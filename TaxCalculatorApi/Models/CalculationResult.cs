using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxCalculatorApi.Models
{
    public class CalculationResult
    {
        public double TotalPackage { get; set; }
        public decimal PayFrequency { get; set; }
        public decimal Superannuation { get; set; }
        public decimal TaxableIncome { get; set; }
        public decimal DeductionTaxableIncome { get; set; }
        public decimal MedicareLevy { get; set; }
        public decimal BudgetRepairLevy { get; set; }
        public decimal IncomeTax { get; set; }
        public decimal Deductions { get; set; }
        public decimal NetIncome { get; set; }
        public decimal PayPacket { get; set; }
    }
}
