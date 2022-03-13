using RestApi_CurrencyCalculator.Core.Models;

namespace RestApi_CurrencyCalculator.AutoMapperConfig.Dtos.CalculatorDtos
{
    public class CalculatorReadDto
    {
        public int CalculatorId { get; set; }
        public decimal ExchangeRate { get; set; }
        public string BaseCurrencyCode { get; set; }
        public string TargetCurrencyCode { get; set; }
    }
}
