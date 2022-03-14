using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

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

        [IgnoreDataMember]
        public ICollection<Calculator> BaseCurrencies { get; set; }

        [IgnoreDataMember]
        public ICollection<Calculator> TargetCurrencies { get; set; }
    }
}
