using RestApi_CurrencyCalculator.Core.IRepositories;
using RestApi_CurrencyCalculator.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public Calculator FindCalculator(string baseCurrCode, string targetCurrCode, out bool isStraightSide)
        {
            Calculator calculator;
            var baseCurr = ApplicationDbContext.Currencies.Where(x => x.Code == baseCurrCode).FirstOrDefault();
            var targetCurr = ApplicationDbContext.Currencies.Where(x => x.Code == targetCurrCode).FirstOrDefault();

            if (baseCurr == null) throw new NullReferenceException($"Unfortunatelly we could not convert {baseCurr.Name}");
            if (targetCurr == null) throw new NullReferenceException($"Unfortunatelly we could not convert {targetCurr.Name}");

            calculator = ApplicationDbContext.Calculators
                .Where(x => x.BaseCurrencyId == baseCurr.CurrencyId && x.TargetCurrencyId == targetCurr.CurrencyId)
                .OrderByDescending(x => x.TimeStamp)
                .FirstOrDefault();

            if (calculator != null)
            {
                isStraightSide = true;
                return calculator;
            }

            isStraightSide = false;
            return ApplicationDbContext.Calculators
                .Where(x => x.BaseCurrencyId == targetCurr.CurrencyId && x.TargetCurrencyId == baseCurr.CurrencyId)
                .OrderByDescending(x => x.TimeStamp)
                .FirstOrDefault();
        }
    }
}
