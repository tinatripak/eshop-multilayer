using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    /// <summary>
    /// Interface for database
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Get all
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> GetAll();
        /// <summary>
        /// Get by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T Get(int id);
        /// <summary>
        /// Find by predicate
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        IEnumerable<T> Find(Func<T, Boolean> predicate);
        /// <summary>
        /// Create an item
        /// </summary>
        /// <param name="item"></param>
        void Create(T item);
        /// <summary>
        /// update an item
        /// </summary>
        /// <param name="item"></param>
        void Update(T item);
        /// <summary>
        /// Delete an item
        /// </summary>
        /// <param name="item"></param>
        void Delete(T item);
        /// <summary>
        /// Delete by id
        /// </summary>
        /// <param name="id"></param>
        void Delete(int id);
    }
}
