using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi_CurrencyCalculator.Core.Models
{
    public class Currency
    {
        public int CurrencyId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

        //Navigation Properties
        public ICollection<Calculator> BaseCurrencies { get; set; }
        public ICollection<Calculator> TargetCurrencies { get; set; }
    }
}
