using Domain.ModelLayer;

namespace BLL.BussinesLogicLayer
{
    public interface IProductService
    {
        Task CreateProduct(ProductModel productModel);
        Task<List<ProductModel>> GetAllProducts();
        Task<ProductModel?> GetProduct(Guid? id);
        Task UpdateProduct(ProductModel productModel);
        Task DeleteProduct(Guid? id);
        Task<int> GetTotalProduct();
    }
}
