using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi_CurrencyCalculator.Core.Models
{
    public partial class Calculator
    {
        public string GetEquivalence(decimal value)
        {
            return (value * ExchangeRate).ToString("0.00");
        }
    }
}
