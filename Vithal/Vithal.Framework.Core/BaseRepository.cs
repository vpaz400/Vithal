using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Vithal.Framework.Core
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly DbContext _context;
        protected readonly DbSet<T> _entities;

        public BaseRepository(DbContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }

        public virtual void Add(T entity)
        {
            _entities.Add(entity);
        }

        public virtual void AddRange(IEnumerable<T> entities)
        {
            _entities.AddRange(entities);
        }

        public virtual void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void UpdateRange(IEnumerable<T> entities)
        {
            foreach (var item in entities)
            {
                _entities.Attach(item);
            }
        }

        public virtual void Remove(T entity)
        {
            _entities.Remove(entity);
        }

        public virtual void RemoveRange(IEnumerable<T> entities)
        {
            _entities.RemoveRange(entities);
        }

        public virtual int Count()
        {
            return _entities.Count();
        }


        public virtual IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _entities.Where(predicate);
        }

        public virtual T GetSingleOrDefault(Expression<Func<T, bool>> predicate)
        {
            return _entities.SingleOrDefault(predicate);
        }

        public virtual T Get(int id)
        {
            return _entities.Find(id);
        }

        public virtual async Task<ResultSet<T>> ListAll(int pageSize = 10, int pageNumber = 1, string sortBy = "Id", SortOrderEnum sortOrder = SortOrderEnum.Ascending)
        {
            var skipCount = pageSize * pageNumber;

            var count = _entities.Count();

            var orderByQuery = $"{sortBy} ASC";

            if (!string.IsNullOrEmpty(sortBy))
            {
                if (sortOrder == SortOrderEnum.Descending)
                {
                    orderByQuery = $"{sortBy} DESC ";
                }
            }

            RawSqlString sql = new RawSqlString($"SELECT * FROM {GetTableName()} ORDER BY {orderByQuery} OFFSET {pageSize * (pageNumber - 1)} ROWS FETCH NEXT {pageSize} ROWS ONLY");
            var results = await _entities.FromSql<T>(sql).ToListAsync();
            return new ResultSet<T>()
            {
                PageNumber = pageNumber,
                TotalRows = count,
                Rows = results,
                SkipCount = skipCount,
                PageSize = pageSize
            };
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
        public void SaveChangesAsync()
        {
            _context.SaveChangesAsync();
        }

        private string GetTableName()
        {
            var obj = default(T);
            return obj.ToString();
        }
    }
}
