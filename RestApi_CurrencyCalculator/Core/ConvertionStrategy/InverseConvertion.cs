namespace RestApi_CurrencyCalculator.Core.ConvertionStrategy
{
    public class InverseConvertion : IConvertionType
    {
        public decimal ConvertCurrency(decimal value, decimal exchangeRate)
        {
            return value / exchangeRate;
        }
    }
}
