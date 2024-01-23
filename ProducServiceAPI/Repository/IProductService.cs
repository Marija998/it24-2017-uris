using ProductServiceAPI.Models;
using ProductServiceAPI.Models.Dtos;

namespace ProductServiceAPI.Repository
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product> GetProductByIdAsync(int id);
        Task<Product> CreateProductAsync(ProductCreateRequest createRequest);
        Task<Product> UpdateProductAsync(int id, ProductUpdateRequest updateRequest);
        Task<bool> DeleteProductAsync(int id);
    }
}
