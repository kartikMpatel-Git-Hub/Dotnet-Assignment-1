using Microsoft.EntityFrameworkCore;
using product_store.Data;
using product_store.Models;
using System.Threading.Tasks;

namespace product_store.Service
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _context;

        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateProduct(ProductModel productModel)
        {
            productModel.Id = Guid.NewGuid();
            _context.Add(productModel);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ProductModel>> GetAllProducts()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<ProductModel?> GetProduct(Guid? id)
        {
            return await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task UpdateProduct(ProductModel productModel)
        {
            _context.Update(productModel);
            await _context.SaveChangesAsync();
        }

        public bool ProductModelExists(Guid id)
        {
            return _context.Products.Any(e => e.Id == id);
        }

        public async Task DeleteProduct(ProductModel productModel)
        {
            _context.Remove(productModel);
            await _context.SaveChangesAsync();
        }
    }
}
