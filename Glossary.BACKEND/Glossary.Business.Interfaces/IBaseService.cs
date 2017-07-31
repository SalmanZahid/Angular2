using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Glossary.Business.Interfaces
{
    public interface IBaseService<T> where T : class
    {
        /// <summary>
        /// Get all from T table
        /// </summary>
        /// <returns>IEnumerable Of T</returns>
        IEnumerable<T> GetAll();

        /// <summary>
        /// Find element by id 
        /// </summary>
        /// <param name="id">int</param>
        /// <returns>Matched by id T Entity</returns>
        T FindById(int id);  
        
        /// <summary>
        /// Add T Entity to database
        /// </summary>
        /// <param name="entity">T</param>
        void Add(T entity);

        /// <summary>
        /// Remove record from T table by id
        /// </summary>
        /// <param name="id">int</param>
        /// <returns>Boolean</returns>
        bool Delete(int id);

        /// <summary>
        /// Update T record
        /// </summary>
        /// <param name="entity">T</param>
        void Update(T entity);      
    }
}
