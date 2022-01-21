using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Vithal.Framework.Core
{
    public interface IBaseRepository<T> where T: BaseEntity
    {
        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
        void Update(T entity);
        void UpdateRange(IEnumerable<T> entities);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
        int Count();
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        T GetSingleOrDefault(Expression<Func<T, bool>> predicate);
        T Get(int id);
        Task<ResultSet<T>> ListAll(int pageSize = 10, int pageNumber = 1, string sortBy = "Id", SortOrderEnum sortOrder = SortOrderEnum.Ascending);
        void SaveChanges();
        void SaveChangesAsync();
    }
}
