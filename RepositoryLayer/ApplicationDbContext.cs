using Microsoft.EntityFrameworkCore;
using Domain.ModelLayer;

namespace DAL.RepositoryLayer
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<ProductModel> Products { get; set; }
    }
}
