using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void AddRange(IEnumerable<T> entity);
        //IEnumerable<T> GetAll();
    }
}
