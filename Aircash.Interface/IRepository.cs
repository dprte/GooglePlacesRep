using System;
using System.Collections.Generic;
using System.Text;

namespace Aircash.Interface
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        bool Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
