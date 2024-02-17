using CartAPI.Models.Product;

namespace CartAPI.Services.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        public IReposatory<Cart> Cart { get; }
        Task<int> OnSaveChangesAsync();
    }
}
