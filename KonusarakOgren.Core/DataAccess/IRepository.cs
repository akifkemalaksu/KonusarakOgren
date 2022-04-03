using KonusarakOgren.Core.Entities;
using System;
using System.Linq.Expressions;

namespace KonusarakOgren.Core.DataAccess
{
    public interface IRepository<T, TKey>
        where T : class, IEntity<TKey>, new()
        where TKey : struct
    {
        public T Insert(T entity);

        public T Update(T entity);

        public void Delete(TKey key);

        public T Get(Expression<Func<T, bool>> expression);

        public ICollection<T> GetMany(Expression<Func<T, bool>>? expression = null);

        public void SaveChanges();
    }
}