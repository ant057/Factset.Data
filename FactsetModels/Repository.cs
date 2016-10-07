using Factset.Data.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Factset.Data.FactsetModels
{
    public class Repository<T> : IGenericRepository<T> where T: class
    {
        private FactsetEntities _db = null;
        private DbSet<T> _table = null;

        public Repository(FactsetEntities db)
        {
            _db = db;
            _table = _db.Set<T>();
        }

        public IEnumerable<T> Query(Expression<Func<T, bool>> filter = null)
        {
            IQueryable<T> query = _table;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return query.ToList();
        }

        public IEnumerable<T> GetAll()
        {
            return _table.ToList();
        }

        public T Get(object id)
        {
            return _table.Find(id);
        }
    }
}