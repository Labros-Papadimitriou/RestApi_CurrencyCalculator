using RestApi_CurrencyCalculator.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi_CurrencyCalculator.Core
{
    public interface IUnitOfWork : IDisposable
    {
        ICurrencyRepository Currencies { get; }
        ICalculatorRepository Calculators { get; }
        int Complete();
    }
}
