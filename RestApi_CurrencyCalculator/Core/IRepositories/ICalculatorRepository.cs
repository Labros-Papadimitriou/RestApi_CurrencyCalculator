using RestApi_CurrencyCalculator.Core.Models;
using System.Collections.Generic;

namespace RestApi_CurrencyCalculator.Core.IRepositories
{
    public interface ICalculatorRepository : IRepository<Calculator>
    {
        object GetCalculatorByIdWithCurrencies(int id);
        IEnumerable<object> GetAllCalculatorsWithCurrencies();
        Calculator FindCalculator(string baseCurrId, string targetCurrId, out bool isStraightSide);

    }
}
