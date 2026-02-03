using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using product_store.Data;
using product_store.Models;

namespace product_store.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public ProductRepository(ApplicationDbContext context,IConfiguration configuration)
        {
            this._context = context;
            this._configuration = configuration;
        }

        public async Task Add(ProductModel product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid? id)
        {
            var product = await GetById(id);
            if (product == null) return;
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ProductModel>> GetAll()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<ProductModel> GetById(Guid? id)
        {
            if (id == null)
                return null;
            return await _context.Products.FindAsync(id);
        }

        public async Task<int> GetTotalCount()
        {
            using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Products", con);
                await con.OpenAsync();
                return (int)await command.ExecuteScalarAsync();
            }
        }

        public async Task Update(ProductModel product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }
    }
}
