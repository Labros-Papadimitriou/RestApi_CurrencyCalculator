using RestApi_CurrencyCalculator.Core.IRepositories;
using System;

namespace RestApi_CurrencyCalculator.Core
{
    public interface IUnitOfWork : IDisposable
    {
        ICurrencyRepository Currencies { get; }
        ICalculatorRepository Calculators { get; }
        int Complete();
    }
}
