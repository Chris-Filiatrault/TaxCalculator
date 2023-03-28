namespace TaxCalculatorUI.Pages
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;

    public class ResultsModel : PageModel
    {

        [BindProperty(SupportsGet = true)]
        public decimal TotalPackage { get; set; }

        [BindProperty(SupportsGet = true)]
        public decimal PayFrequency { get; set; }

        [BindProperty(SupportsGet = true)]
        public decimal Superannuation { get; set; }

        [BindProperty(SupportsGet = true)]
        public decimal TaxableIncome { get; set; }

        [BindProperty(SupportsGet = true)]
        public decimal DeductionTaxableIncome { get; set; }

        [BindProperty(SupportsGet = true)]
        public decimal MedicareLevy { get; set; }

        [BindProperty(SupportsGet = true)]
        public decimal BudgetRepairLevy { get; set; }

        [BindProperty(SupportsGet = true)]
        public decimal IncomeTax { get; set; }

        [BindProperty(SupportsGet = true)]
        public decimal Deductions { get; set; }

        [BindProperty(SupportsGet = true)]
        public decimal NetIncome { get; set; }

        [BindProperty(SupportsGet = true)]
        public decimal PayPacket { get; set; }

        public void OnGet()
        {
        }
    }
}
