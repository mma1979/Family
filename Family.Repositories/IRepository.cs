using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Family.Repositories
{
    public interface IRepository
    {
        IQueryable<T> All<T>(Expression<Func<T, bool>> predicate=null) where T : class;
        T GetOne<T>(Expression<Func<T, bool>> predicate) where T : class;
        IQueryable<T> GetPage<T>(Expression<Func<T, bool>> predicate = null, int pageNumber = 1, int pageSize = 10) where T : class;
        IQueryable<T> GetRows<T>(Expression<Func<T, bool>> predicate = null, int startIndex = 0, int rowsCount = 10) where T : class;

        T Add<T>(T entity) where T : class;
        IEnumerable<T> Add<T>(IEnumerable<T> entities) where T : class;
        T AddOrUpdate<T>(Expression<Func<T, object>> predicate, T entity) where T : class;
        IEnumerable<T> AddOrUpdate<T>(Expression<Func<T, object>> predicate, IEnumerable<T> entities) where T : class;

        T Update<T>(T entity) where T : class;
        T Delete<T>(T entity) where T : class;
        IEnumerable<T> Delete<T>(IEnumerable<T> entities) where T : class;

        IQueryable<T> ExecuteQuery<T>(string sql, object parameters = null) where T : class;
        int ExecuteNoneQuery<T>(string sql, object parameters = null) where T : class;

        object ExecuteScalar<T>(string sql, object parameters = null) where T : class;


    }
}
