using Microsoft.EntityFrameworkCore;
using RestApi_CurrencyCalculator.Core.IRepositories;
using RestApi_CurrencyCalculator.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi_CurrencyCalculator.Persistence.Repositories
{
    public class CalculatorRepository : Repository<Calculator>, ICalculatorRepository
    {
        public CalculatorRepository(ApplicationDbContext context)
            : base(context)
        {
        }
        public ApplicationDbContext ApplicationDbContext => Context as ApplicationDbContext;

        public IEnumerable<object> GetAllCalculatorsWithCurrencies()
        {
            return ApplicationDbContext.Calculators
                .Select(x => new
                {
                    x.CalculatorId,
                    x.ExchangeRate,
                    x.TimeStamp,
                    x.BaseCurrencyId,
                    x.TargetCurrencyId,
                    BaseCurrency = x.BaseCurrency.Name,
                    TargetCurrency = x.TargetCurrency.Name
                }).ToList();
        }
    }
}
