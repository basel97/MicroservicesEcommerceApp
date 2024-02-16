using CouponAPI.Models.Coupon;

namespace CouponAPI.Services.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        public IReposatory<Coupon> Coupon { get; }
        Task<int> OnSaveChangesAsync();
    }
}
