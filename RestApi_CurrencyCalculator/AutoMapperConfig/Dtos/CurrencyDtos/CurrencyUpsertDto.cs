using RestApi_CurrencyCalculator.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi_CurrencyCalculator.AutoMapperConfig.Dtos.CurrencyDtos
{
    public class CurrencyUpsertDto
    {
        [Required]
        public string Code { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
