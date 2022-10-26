using Management.Application.Interfaces.CommonDb.GenericRepository;
using ManagementDbContext.DbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.Services.CommonDb.GenericService
{
    public class GenericService<T> : IGenericRepository<T> where T : class
    {
        protected DbSet<T> _entities;
        protected CommonDbContext _commonDbContext;

        public GenericService(CommonDbContext commonDbContext)
        {
            _commonDbContext = commonDbContext ?? throw new ArgumentNullException(nameof(_commonDbContext));
            _entities = _commonDbContext.Set<T>();
        }

        public void Add(T entity)
        {
            _entities.Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            _entities.AddRange(entities);
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return _entities.Where(expression);
        }

        public IEnumerable<T> GetAll()
        {
            return _entities.ToList();
        }

        public T GetById(int id)
        {
            return _entities.Find(id);
        }

        public void Remove(T entity)
        {
            _entities.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _entities.RemoveRange(entities);
        }

        public void Update(T entity)
        {
            _entities.Attach(entity);
            _commonDbContext.Entry(entity).State = EntityState.Modified;
            _commonDbContext.SaveChanges();
        }
    }
}
