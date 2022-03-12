//using RestApi_CurrencyCalculator.Core.IRepositories;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Linq.Expressions;
//using System.Threading.Tasks;

//namespace RestApi_CurrencyCalculator.Persistence.Repositories
//{
//    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
//    {
//        protected readonly DbContext Context;

//        public Repository(DbContext context)
//        {
//            Context = context;
//        }

//        public TEntity Get(int id)
//        {
//            return Context.Set<TEntity>().Find(id);
//        }

//        public IEnumerable<TEntity> GetAll()
//        {
//            return Context.Set<TEntity>().ToList();
//        }

//        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
//        {
//            return Context.Set<TEntity>().Where(predicate);
//        }

//        public void ModifyEntity(TEntity entity)
//        {
//            Context.Entry(entity).State = EntityState.Modified;
//        }

//        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
//        {
//            return Context.Set<TEntity>().SingleOrDefault(predicate);
//        }

//        public void Add(TEntity entity)
//        {
//            Context.Entry(entity).State = EntityState.Added;
//        }

//        public void AddRange(IEnumerable<TEntity> entities)
//        {
//            foreach (var entity in entities)
//            {
//                Context.Entry(entity).State = EntityState.Added;
//            }
//        }

//        public void Remove(TEntity entity)
//        {
//            Context.Entry(entity).State = EntityState.Deleted;
//        }

//        public void RemoveRange(IEnumerable<TEntity> entities)
//        {
//            foreach (var entity in entities)
//            {
//                Context.Entry(entity).State = EntityState.Deleted;
//            }
//        }
//    }
//}
