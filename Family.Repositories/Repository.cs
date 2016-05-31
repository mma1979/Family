using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Family.Repositories
{
   public class Repository:IRepository,IDisposable
    {
        #region Repository Members
        public DbContext Context { get; set; }
        public Repository(DbContext context)
        {
            Context = context;
        }

        private IEnumerable<object> CreateParameters(object parameters)
        {
            var res = new List<object>();
            foreach (PropertyInfo property in parameters.GetType().GetProperties())
            {
                res.Add(property.GetValue(parameters, null));
            }
            return res;
        }
        #endregion

        #region IRepository Members
        public IQueryable<T> All<T>(Expression<Func<T, bool>> predicate = null) where T : class {
            return predicate == null ?
                Context.Set<T>() :
                Context.Set<T>().Where(predicate);
        }
        public T GetOne<T>(Expression<Func<T, bool>> predicate) where T : class {
            return All(predicate).FirstOrDefault();
        }
        public IQueryable<T> GetPage<T>(Expression<Func<T, bool>> predicate = null, int pageNumber = 1, int pageSize = 10) where T : class {
            return All(predicate).Skip((pageNumber - 1) * pageSize).Take(pageSize);
        }
        public IQueryable<T> GetRows<T>(Expression<Func<T, bool>> predicate = null, int startIndex = 0, int rowsCount = 10) where T : class {
            return All(predicate).Skip(startIndex).Take(rowsCount);
        }

        public T Add<T>(T entity) where T : class {
            Context.Set<T>().Add(entity);
            Context.SaveChanges();
            return entity;
        }
        public IEnumerable<T> Add<T>(IEnumerable<T> entities) where T : class {
            Context.Set<T>().AddRange(entities);
            Context.SaveChanges();
            return entities;
        }
        public T AddOrUpdate<T>(Expression<Func<T, object>> predicate, T entity) where T : class {
            Context.Set<T>().AddOrUpdate(predicate, entity);
            return entity;
        }
        public IEnumerable<T> AddOrUpdate<T>(Expression<Func<T, object>> predicate, IEnumerable<T> entities) where T : class {
            Context.Set<T>().AddOrUpdate(predicate, entities.ToArray());
            return entities;
        }

        public T Update<T>(T entity) where T : class {
            Context.Entry<T>(entity).State = EntityState.Modified;
            Context.Set<T>().Attach(entity);
            Context.SaveChanges();
            return entity;
        }
        public T Delete<T>(T entity) where T : class {
            Context.Set<T>().Remove(entity);
            Context.SaveChanges();
            return entity;
        }
        public IEnumerable<T> Delete<T>(IEnumerable<T> entities) where T : class
        {
            Context.Set<T>().RemoveRange(entities);
            Context.SaveChanges();
            return entities;
        }

        public IQueryable<T> ExecuteQuery<T>(string sql, object parameters = null) where T : class {
            return Context.Database.SqlQuery<T>(sql, CreateParameters(parameters)).AsQueryable();
        }
        public int ExecuteNoneQuery<T>(string sql, object parameters = null) where T : class {
            return Context.Database.ExecuteSqlCommand(sql, CreateParameters(parameters));
        }
       public object ExecuteScalar<T>(string sql, object parameters = null) where T : class
        {
            return Context.Database.SqlQuery<object>(sql, CreateParameters(parameters));
        }
        #endregion

        #region IDisposable Members
        public virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (Context != null)
                    Context.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.Collect();
        }
        #endregion
    }
}
