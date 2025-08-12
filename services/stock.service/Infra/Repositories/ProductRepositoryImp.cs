using Domain.Entities;
using Domain.Interfaces;
using Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories
{
    public class ProductRepositoryImp(AppDbContext context) : BaseRepositoryImp<Product>(context), ProductRepository
    {
        private readonly AppDbContext _context = context;

        public Task<bool> ProductExists(Guid id)
        {
            return _context.Products.AnyAsync(x => x.Id == id);
        }
    }
}
