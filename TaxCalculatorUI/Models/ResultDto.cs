namespace TaxCalculatorUI.Models
{
    public class ResultDto
    {
        public double TotalPackage { get; set; }
        public double PayFrequency { get; set; }
        public double Superannuation { get; set; }
        public double TaxableIncome { get; set; }
        public double DeductionTaxableIncome { get; set; }
        public double MedicareLevy { get; set; }
        public double BudgetRepairLevy { get; set; }
        public double IncomeTax { get; set; }
        public double Deductions { get; set; }
        public double NetIncome { get; set; }
        public double PayPacket { get; set; }
    }
}
