using System.ComponentModel.DataAnnotations;

namespace RestApi_CurrencyCalculator.AutoMapperConfig.Dtos.CalculatorDtos
{
    public class CalculatorCreateDto
    {
        [Required]
        public decimal ExchangeRate { get; set; }

        [Required]
        public string BaseCurrencyCode { get; set; }
        public string BaseCurrencyName { get; set; }

        [Required]
        public string TargetCurrencyCode { get; set; }
        public string TargetCurrencyName { get; set; }

    }
}
