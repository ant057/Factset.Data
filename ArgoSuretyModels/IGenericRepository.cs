using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Factset.Data.ArgoSuretyModels
{
    public interface IGenericRepository<T> where T : class
    {
        T Get(object id);
        IEnumerable<T> GetAll();
        void Add(T obj);
        IEnumerable<T> Query(Expression<Func<T, bool>> filter = null);
        void CallSP(string name, params object[] parameters);
    }
}
