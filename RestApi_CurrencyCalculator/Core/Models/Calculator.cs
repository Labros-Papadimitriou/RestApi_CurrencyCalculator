using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi_CurrencyCalculator.Core.Models
{
    public class Calculator
    {
        public Calculator()
        {
            TimeStamp = DateTime.Now;
        }

        [Key]
        public int CalculatorId { get; set; }

        [Required]
        public decimal ExchangeRate { get; set; }

        public DateTime TimeStamp { get; set; }

        //Foreign Keys
        public int BaseCurrencyId { get; set; }
        public int TargetCurrencyId { get; set; }

        //Navigation Properties
        public Currency BaseCurrency { get; set; }
        public Currency TargetCurrency { get; set; }
        
    }
}
