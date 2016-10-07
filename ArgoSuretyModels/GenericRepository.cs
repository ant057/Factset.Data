using Factset.Data.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Factset.Data.ArgoSuretyModels
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private ArgoSuretyEntities _db = null;
        private DbSet<T> _table = null;

        public GenericRepository(ArgoSuretyEntities db)
        {
            _db = db;
            _table = _db.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return _table.ToList();
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

        public T Get(object id)
        {
            return _table.Find(id);
        }

        public void Add(T obj)
        {
            _table.Add(obj);
        }

        public void CallSP(string name, params object[] parameters)
        {
            _db.Database.ExecuteSqlCommand(name, parameters);
        }
    }
}