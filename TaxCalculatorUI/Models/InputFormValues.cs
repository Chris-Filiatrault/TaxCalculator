using System.ComponentModel.DataAnnotations;

namespace TaxCalculatorUI.Models
{
    public class InputFormValues
    {
        // TODO: Fix bug where calculations are set to 0 when user enters decimal
        [Required]
        public double TotalPackage { get; set; }

        [Required]
        public char PayFrequency { get; set; }
    }
}
