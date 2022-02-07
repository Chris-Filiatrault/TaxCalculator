using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using TaxCalculatorUI.Clients;
using TaxCalculatorUI.Models;


namespace TaxCalculatorUI.Pages
{
    using System.Globalization;

    public class IndexModel : PageModel
    {
        [BindProperty]
        public double TotalPackage { get; set; }

        [BindProperty]
        public int PayFrequency { get; set; }

        public List<SelectListItem> PayFrequencyOptions = new()
        {
            new SelectListItem {Text = "Weekly", Value = "52"},
            new SelectListItem {Text = "Fortnightly", Value = "26"},
            new SelectListItem {Text = "Monthly", Value = "12"}
        };

        public string CurrencySymbol { get; set; } = CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol;

        public void OnGet()
        {
        }

        public IActionResult OnPost([FromServices] TaxCalculatorApiClient client)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            else
            {
                // Todo: make controller and call client from there
                var results = client.CallTaxCalculatorApi(TotalPackage, PayFrequency);

                return RedirectToPage("/Results", results);
            }
        }
    }
}
