using Domain.ModelLayer;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace DAL.RepositoryLayer
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            this._context = context;
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
            using (SqlConnection con = new SqlConnection("Server=localhost\\SQLEXPRESS;Database=shop_db;User Id=sa;Password=K@rtik.Patel.1302;TrustServerCertificate=True;"))
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
