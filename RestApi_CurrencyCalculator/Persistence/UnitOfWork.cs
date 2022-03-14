using RestApi_CurrencyCalculator.Core;
using RestApi_CurrencyCalculator.Core.IRepositories;
using RestApi_CurrencyCalculator.Persistence.Repositories;

namespace RestApi_CurrencyCalculator.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext db)
        {
            _context = db;
            Currencies = new CurrencyRepository(_context);
            Calculators = new CalculatorRepository(_context);
        }

        public ICurrencyRepository Currencies { get; private set; }
        public ICalculatorRepository Calculators { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
