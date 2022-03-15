using RestApi_CurrencyCalculator.Core.ConvertionStrategy;

namespace RestApi_CurrencyCalculator.Core.Models
{
    public partial class Calculator
    {
        public void SetConvertionType(IConvertionType convertionType)
        {
            _convertionType = convertionType;
        }
        public decimal Convert(decimal value)
        {
            return _convertionType.ConvertCurrency(value, ExchangeRate);
        }
    }
}
