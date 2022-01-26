using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TaxCalculatorUI.Clients;
using TaxCalculatorUI.Models;


namespace TaxCalculatorUI.Pages
{
    public class IndexModel : PageModel
    {
        // Can use properties of this object when submitting the form to collect data
        [BindProperty]
        public InputFormValues InputFormValues { get; set; }

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
                var results = client.CallTaxCalculatorApi(InputFormValues.TotalPackage);

                // Redirect to results page and pass in values in anonymous object 
                return RedirectToPage("/Results", results);
            }
        }
    }
}
