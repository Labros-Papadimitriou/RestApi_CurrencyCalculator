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
                    x.BaseCurrencyId,
                    x.TargetCurrencyId,
                    BaseCurrency = x.BaseCurrency.Name,
                    TargetCurrency = x.TargetCurrency.Name
                }).ToList();
        }

        public object GetCalculatorByIdWithCurrencies(int id)
        {
            var calculator = ApplicationDbContext.Calculators
                .Where(x => x.CalculatorId == id)
                .Select(x => new
                {
                    x.CalculatorId,
                    x.ExchangeRate,
                    x.BaseCurrencyId,
                    x.TargetCurrencyId,
                    BaseCurrency = x.BaseCurrency.Name,
                    TargetCurrency = x.TargetCurrency.Name
                }
                ).FirstOrDefault();
            
            if (calculator == null)
            {
                return new { message = "No Calculator found with this Id" };
            }

            return calculator;
        }

        public Calculator FindCalculator(string baseCurrCode, string targetCurrCode)
        {
            try
            {
                var baseCurrId = ApplicationDbContext.Currencies
                        .Where(x => x.Code == baseCurrCode)
                        .FirstOrDefault()
                        .CurrencyId;

                var targetCurrId = ApplicationDbContext.Currencies
                    .Where(x => x.Code == targetCurrCode)
                    .FirstOrDefault()
                    .CurrencyId;

                var calculator = ApplicationDbContext.Calculators
                    .Where(x => x.BaseCurrencyId == baseCurrId && x.TargetCurrencyId == targetCurrId)
                    .OrderByDescending(x => x.TimeStamp)
                    .FirstOrDefault();

                return calculator;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
