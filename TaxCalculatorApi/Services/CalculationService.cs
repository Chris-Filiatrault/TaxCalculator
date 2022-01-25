using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxCalculatorApi.Functions;
using TaxCalculatorApi.Models;

namespace TaxCalculatorApi.Services
{
    public class CalculationService : ICalculationService
    {
        public double CalculateTax(double income)
        {
            // TODO: Assign values using Functions
            CalculationResult calculationResult = new();

            calculationResult.TotalPackage = income;
            return calculationResult.TotalPackage * 3;

        }
    }
}
