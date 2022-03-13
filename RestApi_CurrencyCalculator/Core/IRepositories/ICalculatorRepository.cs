using RestApi_CurrencyCalculator.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi_CurrencyCalculator.Core.IRepositories
{
    public interface ICalculatorRepository : IRepository<Calculator>
    {
        object GetCalculatorByIdWithCurrencies(int id);
        IEnumerable<object> GetAllCalculatorsWithCurrencies();
        Calculator FindCalculator(string baseCurrId, string targetCurrId, out bool isStraightSide);

    }
}
