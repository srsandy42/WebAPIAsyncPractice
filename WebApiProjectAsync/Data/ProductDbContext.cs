using Microsoft.EntityFrameworkCore;
using WebApiProjectAsync.Model;

namespace WebApiProjectAsync.Data
{
    public class ProductDbContext:DbContext
    {
        public ProductDbContext(DbContextOptions options):base(options)
    {
            
    }
        public DbSet<Product> Products { get; set; }
    }
}
