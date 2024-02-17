using CartAPI.Data;
using CartAPI.Models.Product;
using CartAPI.Services.Interfaces;

namespace CartAPI.Services.Classes
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _db;
        public IReposatory<Cart> Cart { get; private set; }

        public UnitOfWork(AppDbContext db)
        {
            _db = db;
            Cart = new Reposatory<Cart>(_db);
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
