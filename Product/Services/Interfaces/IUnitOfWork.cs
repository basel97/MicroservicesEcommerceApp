using ProductAPI.Models.Product;

namespace ProductAPI.Services.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        public IReposatory<Product> Product { get; }
        Task<int> OnSaveChangesAsync();
    }
}
