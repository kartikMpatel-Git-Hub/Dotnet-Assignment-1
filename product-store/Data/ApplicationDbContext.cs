using Microsoft.EntityFrameworkCore;
using product_store.Models;
namespace product_store.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<ProductModel> Products { get; set; }
    }
}
