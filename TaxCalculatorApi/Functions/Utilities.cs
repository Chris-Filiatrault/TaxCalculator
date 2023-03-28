namespace TaxCalculatorApi.Functions
{
    using System;
    using System.Globalization;

    public class Utilities
    {
        public static decimal RoundUp(decimal input, int places)
        {
            return decimal.Round(input, places, MidpointRounding.ToPositiveInfinity);
        }        
        
        public static string RemoveDollarSymbol(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }
            
            return input.StartsWith('$') ? input.TrimStart('$') : input;    
        }

        public static string ConvertToCurrency(decimal amount)
        {
            return amount.ToString("C", CultureInfo.CurrentCulture);
        }

    }
}