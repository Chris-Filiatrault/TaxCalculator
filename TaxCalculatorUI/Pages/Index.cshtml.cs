namespace TaxCalculatorUI.Pages {

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Threading.Tasks;
    using TaxCalculatorUI.Services;

    public class IndexModel : PageModel
    {
        private readonly ITaxCalculatorService taxCalculatorService;

        [BindProperty]
        public decimal TotalPackage { get; set; }

        [BindProperty]
        public int PayFrequency { get; set; }

        public List<SelectListItem> PayFrequencyOptions { get; set; } = new()
        {
            new SelectListItem {Text = "Weekly", Value = "52"},
            new SelectListItem {Text = "Fortnightly", Value = "26"},
            new SelectListItem {Text = "Monthly", Value = "12"}
        };

        public string CurrencySymbol { get; set; } = CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol;

        public IndexModel(ITaxCalculatorService taxCalculatorService)
        {
            this.taxCalculatorService = taxCalculatorService;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            else
            {
                var results = await taxCalculatorService.CalculateTax(TotalPackage, PayFrequency);

                return RedirectToPage("/Results", results);
            }
        }
    }
}
