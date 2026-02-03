using Microsoft.EntityFrameworkCore;
using product_store.Data;
using product_store.Models;
using product_store.Repository;
using System.Threading.Tasks;

namespace product_store.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            this._repository = repository;
        }

        public async Task CreateProduct(ProductModel productModel)
        {
            Validate(productModel);
            await _repository.Add(productModel);
        }

        public async Task DeleteProduct(Guid? id)
        {
            await _repository.Delete(id);
        }

        public async Task<List<ProductModel>> GetAllProducts()
        {
            return await _repository.GetAll();
        }

        public async Task<ProductModel?> GetProduct(Guid? id)
        {
            return await _repository.GetById(id);
        }

        public async Task<int> GetTotalProduct()
        {
            return await _repository.GetTotalCount();
        }

        public async Task UpdateProduct(ProductModel productModel)
        {
            Validate(productModel);
            await _repository.Update(productModel);
        }

        private void Validate(ProductModel product)
        {
            if (product.Price <= 0)
                throw new Exception("Price Must Be Positive !");
        }
    }
}
