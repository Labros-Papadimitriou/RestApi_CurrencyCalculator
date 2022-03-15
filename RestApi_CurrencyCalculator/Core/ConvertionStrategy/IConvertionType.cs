namespace RestApi_CurrencyCalculator.Core.ConvertionStrategy
{
    public interface IConvertionType
    {
        decimal ConvertCurrency(decimal value, decimal exchangeRate);
    }
}
