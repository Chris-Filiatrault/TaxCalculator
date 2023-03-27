﻿namespace TaxCalculatorUI.Pages {

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.Collections.Generic;
    using System.Globalization;
    
    using TaxCalculatorUI.Services;

    public class IndexModel : PageModel
    {
        private readonly TaxCalculatorService taxCalculatorService;

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

        public IndexModel(TaxCalculatorService taxCalculatorService)
        {
            this.taxCalculatorService = taxCalculatorService;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            else
            {
                var results = taxCalculatorService.CalculateTax(TotalPackage, PayFrequency);

                return RedirectToPage("/Results", results);
            }
        }
    }
}
