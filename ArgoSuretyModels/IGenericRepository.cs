using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factset.Data.ArgoSuretyModels
{
    public interface IGenericRepository<T> where T : class
    {
        T Get(object id);
        IEnumerable<T> GetAll();
        void Add(T obj);
    }
}
