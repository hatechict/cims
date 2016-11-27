using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CIMS.Data.Infrastructure
{
    public interface IGenericRepository<T> where T : class
    {
        void Insert(T entity);
        void Insert(IEnumerable<T> entities);
        void Delete(T entityToDelete);
        void Delete(object id);
        void Delete(List<object> ids);
        void DeleteAll(IEnumerable<T> entities);
        void Edit(T entityToUpdate);
        void Edit(IEnumerable<T> entitiesToUpdate);
        T GetById(object id);
        IEnumerable<T> Get(
        Expression<Func<T, bool>> filter = null,
        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
        string includeProperties = "");
        IEnumerable<T> GetByQuery(string sqlQuery);
        T GetFirst();
        T GetLast();
    }
}
