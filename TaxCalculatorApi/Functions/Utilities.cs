using System;
using System.Linq;
using System.Globalization;

namespace TaxCalculatorApi.Functions
{
    public class Utilities
    {
        public static double RoundUp(double input, int places)
        {
            double multiplier = Math.Pow(10, Convert.ToDouble(places));
            return Math.Ceiling(input * multiplier) / multiplier;
        }        
        
        public static string RemoveDollarSymbol(string input)
        {
            if (input != "")
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