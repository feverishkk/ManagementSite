using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Management.Application.Interfaces.CommonDb.GenericRepository
{
    public interface IGenericRepository<T> where T : class
    {
        T GetById(int id);
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);
        void Add(T entity);
        /// <summary>
        /// Add a list of records
        /// </summary>
        /// <param name="entities"></param>
        void AddRange(IEnumerable<T> entities);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);

        void Update(T entity);
    }
}