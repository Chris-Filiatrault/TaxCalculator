namespace TaxCalculatorUI.Pages
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;

    public class ResultsModel : PageModel
    {

        [BindProperty(SupportsGet = true)]
        public double TotalPackage { get; set; }

        [BindProperty(SupportsGet = true)]
        public double PayFrequency { get; set; }

        [BindProperty(SupportsGet = true)]
        public double Superannuation { get; set; }

        [BindProperty(SupportsGet = true)]
        public double TaxableIncome { get; set; }

        [BindProperty(SupportsGet = true)]
        public double DeductionTaxableIncome { get; set; }

        [BindProperty(SupportsGet = true)]
        public double MedicareLevy { get; set; }

        [BindProperty(SupportsGet = true)]
        public double BudgetRepairLevy { get; set; }

        [BindProperty(SupportsGet = true)]
        public double IncomeTax { get; set; }

        [BindProperty(SupportsGet = true)]
        public double Deductions { get; set; }

        [BindProperty(SupportsGet = true)]
        public double NetIncome { get; set; }

        [BindProperty(SupportsGet = true)]
        public double PayPacket { get; set; }

        public void OnGet()
        {
        }
    }
}
