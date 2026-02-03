using Domain.ModelLayer;
using DAL.RepositoryLayer;

namespace BLL.BussinesLogicLayer
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repo;

        public ProductService(IProductRepository repo)
        {
            _repo = repo;
        }
        public async Task CreateProduct(ProductModel productModel)
        {
            Validate(productModel);
            await _repo.Add(productModel);
        }

        public async Task<List<ProductModel>> GetAllProducts()
        {
            return await _repo.GetAll();
        }

        public async Task<ProductModel?> GetProduct(Guid? id)
        {
            return await _repo.GetById(id);
        }

        public async Task UpdateProduct(ProductModel productModel)
        {
            Validate(productModel);
            await _repo.Update(productModel);
        }

        public async Task DeleteProduct(Guid? id)
        {
            await _repo.Delete(id);
        }

        public async Task<int> GetTotalProduct()
        {
            return await _repo.GetTotalCount();
        }

        private void Validate(ProductModel product)
        {
            if (product.Price <= 0)
                throw new Exception("Price must be positive");
        }
    }
}
