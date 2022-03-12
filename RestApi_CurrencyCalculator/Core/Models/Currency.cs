using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi_CurrencyCalculator.Core.Models
{
    public class Currency
    {
        [Key]
        public int CurrencyId { get; set; }

        [Required]
        public string Code { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        //Navigation Properties
        public ICollection<Calculator> BaseCurrencies { get; set; }
        public ICollection<Calculator> TargetCurrencies { get; set; }
    }
}
