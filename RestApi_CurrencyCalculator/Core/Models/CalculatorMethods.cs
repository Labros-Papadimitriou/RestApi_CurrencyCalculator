using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi_CurrencyCalculator.Core.Models
{
    public partial class Calculator
    {
        public decimal GetEquivalence(decimal value)
        {
            return (value * ExchangeRate);
        }
    }
}
