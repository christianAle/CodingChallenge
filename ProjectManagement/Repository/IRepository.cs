using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    interface IRepository<T>
    {
        void Create(T entity);
        List<T> Retrive();
    }
}
