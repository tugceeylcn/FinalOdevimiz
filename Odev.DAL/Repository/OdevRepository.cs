using Odev.DAL.Models;
using Odev.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace Odev.DAL.Repository
{
    public class OdevRepository<T> where T : BaseModel
    {
        private readonly DbContext _baContext;
        private readonly DbSet<T> _dbSet;

        public OdevRepository(OdevUnitOfWork uow)
        {
            _baContext = uow.GetContext();
            _dbSet = _baContext.Set<T>();
        }
        public virtual void Add(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(typeof(T).Name + " boş olamaz");

            entity.IsDeleted = false;
            _dbSet.Add(entity);
        }

        public virtual void Update(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(typeof(T).Name + " boş olamaz.");

            _dbSet.Attach(entity);
            _baContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(typeof(T).Name + " boş olamaz.");

            entity.IsDeleted = true;
            entity.IsActive = false;
            Update(entity);
        }

        public virtual void Delete(Expression<Func<T, bool>> query)
        {
            if (query == null) throw new ArgumentNullException(typeof(T).Name + " sorgu boş olamaz.");

            ICollection<T> list = GetList(query).ToList();
            foreach (var item in list)
            {
                item.IsDeleted = true;
                item.IsActive = false;
                Update(item);
            }
        }

        public virtual T Get(Expression<Func<T, bool>> query, params Expression<Func<T, object>>[] includeExpressions)
        {
            var newquery = _dbSet.Where(x => x.IsDeleted == false);

            if (includeExpressions.Any())
                newquery = includeExpressions.Aggregate(newquery, (current, includeExpression) => current.Include(includeExpression));

            var result = newquery.SingleOrDefault(query);

            return result;
        }

        public virtual T GetAll(Expression<Func<T, bool>> query, params Expression<Func<T, object>>[] includeExpressions)
        {
            var newquery = _dbSet.Where(x => x.IsDeleted == false || x.IsDeleted == true);

            if (includeExpressions.Any())
                newquery = includeExpressions.Aggregate(newquery, (current, includeExpression) => current.Include(includeExpression));

            var result = newquery.SingleOrDefault(query);

            return result;
        }

        public virtual IQueryable<T> GetList(Expression<Func<T, bool>> query = null, params Expression<Func<T, object>>[] includeExpressions)
        {
            var newquery = _dbSet.Where(x => x.IsDeleted == false);

            if (query != null)
                newquery = newquery.Where(query);


            if (includeExpressions.Any())
                newquery = includeExpressions.Aggregate(newquery, (current, includeExpression) => current.Include(includeExpression));


            return newquery;
        }

        public virtual int GetCount(Expression<Func<T, bool>> query = null)
        {
            return query == null ? _dbSet.Count(x => x.IsDeleted == false) : _dbSet.Where(x => x.IsDeleted == false).Count(query);
        }

        public virtual bool Any(Expression<Func<T, bool>> query = null)
        {
            return query == null ? _dbSet.Any(x => x.IsDeleted == false) : _dbSet.Where(x => x.IsDeleted == false).Any(query);
        }
    }
}