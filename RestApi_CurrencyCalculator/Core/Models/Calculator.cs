using RestApi_CurrencyCalculator.Core.ConvertionStrategy;
using System;
using System.ComponentModel.DataAnnotations;

namespace RestApi_CurrencyCalculator.Core.Models
{
    public partial class Calculator
    {
        private IConvertionType _convertionType;
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
