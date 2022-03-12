//using RestApi_CurrencyCalculator.Core;
//using RestApi_CurrencyCalculator.Core.IRepositories;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace RestApi_CurrencyCalculator.Persistence
//{
//    public class UnitOfWork : IUnitOfWork
//    {
//        private readonly ApplicationDbContext _db;

//        public UnitOfWork(ApplicationDbContext db)
//        {
//            _db = db;
//            Currencies = new CurrencyRepository(_context);
//            Calculators = new CalculatorRepository(_context);
//        }

//        public ICurrencyRepository Currencies { get; private set; }
//        public ICalculatorRepository Calculators { get; private set; }

//        public int Complete()
//        {
//            return _db.SaveChanges();
//        }

//        public void Dispose()
//        {
//            _db.Dispose();
//        }
//    }
//}
