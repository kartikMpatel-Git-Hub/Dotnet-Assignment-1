using Domain.ModelLayer;

namespace DAL.RepositoryLayer
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
