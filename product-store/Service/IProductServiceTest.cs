using product_store.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace product_store.Service
{
    public interface IProductServiceTest
    {
        Task CreateProduct(ProductModel productModel);
        Task<List<ProductModel>> GetAllProducts();
        Task<ProductModel?> GetProduct(Guid? id);
        Task UpdateProduct(ProductModel productModel);
        Task DeleteProduct(Guid? id);
        Task<int> GetTotalProduct();
    }
}
