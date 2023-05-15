using WebApiProjectAsync.Dto;

namespace WebApiProjectAsync.Repository
{
    public interface IProductRepository
    {
        Task<List<ProductDto>> GetAllProductAsync();
        Task<int> AddProductAsync(ProductDto productDto);
        Task<ProductDto> GetProductByIdAsync(int id);
        Task UpdateProductAsync(int id,ProductDto productDto);
        Task DeleteProductAsync(int id);
    }
}
