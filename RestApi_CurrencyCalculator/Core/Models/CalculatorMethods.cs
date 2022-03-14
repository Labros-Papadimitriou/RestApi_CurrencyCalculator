namespace RestApi_CurrencyCalculator.Core.Models
{
    public partial class Calculator
    {
        public decimal GetEquivalence(decimal value)
        {
            return value * ExchangeRate;
        }
        public decimal GetInverseEquivalence(decimal value)
        {
            return value / ExchangeRate;
        }
    }
}
