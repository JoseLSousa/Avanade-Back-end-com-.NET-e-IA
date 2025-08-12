using Domain.Entities;

namespace Domain.Interfaces
{
    public interface ProductRepository : BaseRepository<Product>
    {
        Task<bool> ProductExists(Guid id);
    }
}
