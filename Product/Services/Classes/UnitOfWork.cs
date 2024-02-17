using ProductAPI.Data;
using ProductAPI.Models.Product;
using ProductAPI.Services.Interfaces;

namespace ProductAPI.Services.Classes
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _db;
        public IReposatory<Product> Product { get; private set; }

        public UnitOfWork(AppDbContext db)
        {
            _db = db;
            Product = new Reposatory<Product>(_db);
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
