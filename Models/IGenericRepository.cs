using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Factset.Data.Models
{
    public interface IGenericRepository<T> where T:class
    {
        IEnumerable<T> Query(Expression<Func<T, bool>> filter = null);
        T Get(object id);
        IEnumerable<T> GetAll();
    }
}
