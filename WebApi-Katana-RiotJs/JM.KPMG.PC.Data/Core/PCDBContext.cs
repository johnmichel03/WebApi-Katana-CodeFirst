using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JM.KPMG.PC.Data.Core
{
    public class PCDBContext : DbContext, IRepository
    {

        public PCDBContext(string nameOrConnectionString) : base(nameOrConnectionString)
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

        public T Add<T>(T entity) where T : class
        {
            this.Set<T>().Add(entity);
            return entity;
        }

        public T Delete<T>(T entity) where T : class
        {
            this.Set<T>().Remove(entity);
            return entity;
        }

        public T Update<T>(T entity) where T : class
        {
            this.Set<T>().Attach(entity);
            return entity;
        }

        public IQueryable<T> Query<T>(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includes) where T : class
        {
            var query = this.Set<T>().Where(where);
            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }
            return query;
        }

        public void Save()
        {
            SaveChanges();
        }


    }
}
