using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public interface IBaseRepository<T> where T:class
    {
        IEnumerable<T> GetAll();
        void Add(ref T item);
        void Remove(T itemToDelete);
        void Update(T item);
    }
}
