using System.Linq.Expressions;

namespace CouponAPI.Services.Interfaces
{
    public interface IReposatory<T>
    {
        Task<T> GetAsync(Expression<Func<T, bool>> where, string[]? includes = null);
        Task<T> GetByIdAsync(Expression<Func<T, bool>> where, string[]? includes = null);
        Task<T> AddAsync(T entity);
        T Update(T entity);
        Task<IEnumerable<T>> OnGetAllAsync(Expression<Func<T, bool>>? condition = null, string[]? includes = null);
        void OnDelete(T entity);
    }
}
