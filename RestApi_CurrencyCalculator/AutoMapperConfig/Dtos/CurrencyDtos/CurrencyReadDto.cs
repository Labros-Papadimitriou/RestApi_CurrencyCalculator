using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi_CurrencyCalculator.AutoMapper.Dtos.CurrencyDtos
{
    public class CurrencyReadDto
    {
        public int CurrencyId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
