namespace TaxCalculatorUI.Pages {

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.Extensions.Logging;
    
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Globalization;
    
    using TaxCalculatorUI.Clients;

    public class IndexModel : PageModel
    {
        private readonly ILogger Logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            Logger = logger;
        }

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
            Trace.TraceError("Test: Log from Tracer");
            Logger.LogInformation("Test: log from ILogger");
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
