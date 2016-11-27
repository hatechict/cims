using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CIMS.Data.Infrastructure
{
    public class GenericRepository<T> :IGenericRepository<T> where T : class
    {
        internal CimsContext cimsContext;
        internal DbSet<T> dbSet;
        public GenericRepository(CimsContext context)
        {
            this.cimsContext = context;
            this.dbSet = cimsContext.Set<T>();
        }

        public virtual IEnumerable<T> Get(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<T> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public virtual T GetById(object id)
        {
            return dbSet.Find(id);
        }

        public virtual IEnumerable<T> GetByQuery(string sqlQuery)
        {
            return dbSet.SqlQuery(sqlQuery);
        }
        public virtual T GetFirst()
        {
            return Get().First();
        }
        public virtual T GetLast()
        {
            return Get().Last();
        }
        public virtual void Insert(T entity)
        {
            dbSet.Add(entity);
        }

        public virtual void Insert(IEnumerable<T> entities)
        {
            dbSet.AddRange(entities);
        }
        public virtual void Delete(object id)
        {
            T entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
        }
        public virtual void Delete(List<object> ids)
        {
            foreach (var id in ids)
            {
                Delete(id);
            }
        }
        public virtual void Delete(T entityToDelete)
        {
            if (cimsContext.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);

        }
        public virtual void Edit(T entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            cimsContext.Entry(entityToUpdate).State = EntityState.Modified;
        }

        public virtual void Edit(IEnumerable<T> entitiesToUpdate)
        {
            foreach (T entityToUpdate in entitiesToUpdate)
            {
                dbSet.Attach(entityToUpdate);
                cimsContext.Entry(entityToUpdate).State = EntityState.Modified;
            }
        }

        public virtual void DeleteBySqlQuery(string sqlQuery)
        {
            using (var payroll = new CimsContext())
            {
                payroll.Database.ExecuteSqlCommand(sqlQuery);
            }
        }

        public virtual void DeleteAll(IEnumerable<T> entities)
        {
            dbSet.RemoveRange(entities);
        }
    }
}
