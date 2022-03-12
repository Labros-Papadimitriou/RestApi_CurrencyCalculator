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

        public ApplicationDbContext MySchoolContext => Context as ApplicationDbContext;
    }
}
