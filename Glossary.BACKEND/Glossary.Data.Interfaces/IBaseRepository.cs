using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Glossary.Data.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T FindById(int id);
        void Add(T entity);
        bool Delete(int id);
        void Update(T entity);
    }
}
