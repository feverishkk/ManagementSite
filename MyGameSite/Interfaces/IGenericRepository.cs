using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MyGameSite.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll(string _tableName);
        Task<IEnumerable<T>> GetById(string _tableName, int id);

    }
}
