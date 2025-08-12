using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> context) : DbContext(context)
    {
        public DbSet<Product> Products { get; set; }
    }
}
