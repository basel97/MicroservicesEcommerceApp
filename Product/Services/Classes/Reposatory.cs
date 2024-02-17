using ProductAPI.Data;
using ProductAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace ProductAPI.Services.Classes
{
    public class Reposatory<T> : IReposatory<T> where T : class
    {
        private readonly AppDbContext _db;

        public Reposatory(AppDbContext db)
        {
            _db = db;
        }
        public async Task<T> GetAsync(Expression<Func<T, bool>> where, string[]? includes = null)
        {
            IQueryable<T> data = _db.Set<T>();
            if (includes is not null)
            {
                foreach (var include in includes)
                {
                    data = data.Include(include);
                }
            }
            return await data.FirstOrDefaultAsync(where);
        }
        public async Task<T> GetByIdAsync(Expression<Func<T, bool>> where, string[]? includes = null)
        {
            IQueryable<T> data = _db.Set<T>();
            if (includes is not null)
            {
                foreach (var include in includes)
                {
                    data = data.Include(include);
                }
            }
            return await data.SingleOrDefaultAsync(where);
        }
        public async Task<T> AddAsync(T entity)
        {
            EntityEntry<T> data = await _db.Set<T>().AddAsync(entity);
            return entity;
        }
        public T Update(T entity)
        {
            EntityEntry<T> data = _db.Set<T>().Update(entity);
            return entity;
        }
        public async Task<IEnumerable<T>> OnGetAllAsync(Expression<Func<T, bool>>? condition = null, string[]? includes = null
          )
        {
            IQueryable<T> query = _db.Set<T>();
            if (condition != null)
            {
                query = query.Where(condition);
            }
            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }
            return await query.ToListAsync();
        }
        public void OnDelete(T entity)
        {
            _db.Remove(entity);
        }
    }
}
