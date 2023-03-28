namespace TaxCalculatorApi.Functions
{
    using System;
    using System.Globalization;

    public class Utilities
    {
        public static double RoundUp(double input, int places)
        {
            double multiplier = Math.Pow(10, Convert.ToDouble(places));
            return Math.Ceiling(input * multiplier) / multiplier;
        }        
        
        public static string RemoveDollarSymbol(string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                return input.StartsWith('$') ? input.TrimStart('$') : input;    
            }
            else
            {
                return input;
            }
        }

        public static string ConvertToCurrency(double amount)
        {
            return amount.ToString("C", CultureInfo.CurrentCulture);
        }

    }
}