using CouponAPI.Data;
using CouponAPI.Models.Coupon;
using CouponAPI.Services.Interfaces;

namespace CouponAPI.Services.Classes
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _db;
        public IReposatory<Coupon> Coupon { get; private set; }

        public UnitOfWork(AppDbContext db)
        {
            _db = db;
            Coupon = new Reposatory<Coupon>(_db);
        }


        public async void Dispose()
        {
            await _db.DisposeAsync();
        }

        public async Task<int> OnSaveChangesAsync()
        {
            return await _db.SaveChangesAsync();
        }
    }
}
