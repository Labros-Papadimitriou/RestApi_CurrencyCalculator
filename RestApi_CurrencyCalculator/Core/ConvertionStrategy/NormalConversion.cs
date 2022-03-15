namespace RestApi_CurrencyCalculator.Core.ConvertionStrategy
{
    public class NormalConversion : IConvertionType
    {
        public decimal ConvertCurrency(decimal value, decimal exchangeRate)
        {
            return value * exchangeRate;
        }
    }
}
