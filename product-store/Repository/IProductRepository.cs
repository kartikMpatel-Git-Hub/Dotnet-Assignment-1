using product_store.Models;

namespace product_store.Repository
{
    public interface IProductRepository
    {
        Task<List<ProductModel>> GetAll();

        Task<ProductModel> GetById(Guid? id);
        Task Add(ProductModel product);
        Task Update(ProductModel product);
        Task<int> GetTotalCount();
        Task Delete(Guid? id);

    }
}
