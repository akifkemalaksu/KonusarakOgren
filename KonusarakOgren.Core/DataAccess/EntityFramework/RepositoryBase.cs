using KonusarakOgren.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;

namespace KonusarakOgren.Core.DataAccess.EntityFramework
{
    public class RepositoryBase<TContext, T, TKey> : IRepository<T, TKey>, IDisposable
        where TContext : DbContext, new()
        where T : class, IEntity<TKey>, new()
        where TKey : struct
    {
        protected readonly TContext _context;
        protected readonly DbSet<T> _dbSet;
        private bool _disposed = false;

        #region Repository

        public RepositoryBase(TContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        private void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void Delete(TKey key)
        {
            var entity = Get(key);
            Delete(entity);
        }

        public T Get(Expression<Func<T, bool>> expression) => _dbSet.Where(expression).FirstOrDefault();

        public ICollection<T> GetMany(Expression<Func<T, bool>>? expression = null) => expression == null ? _dbSet.ToList() : _dbSet.Where(expression).ToList();

        public T Insert(T entity)
        {
            entity.CreateDate = DateTime.Now;
            _dbSet.Add(entity);
            return entity;
        }

        public T Update(T entity)
        {
            _dbSet.Update(entity);
            return entity;
        }

        private T Get(TKey key) => _dbSet.Find(key);

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        #endregion Repository

        #region Dispose

        ~RepositoryBase()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing && !_disposed)
            {
                _context.Dispose();
            }
            _disposed = true;
        }

        #endregion Dispose
    }
}