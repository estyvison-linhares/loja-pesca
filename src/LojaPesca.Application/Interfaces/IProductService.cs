using LojaPesca.Application.DTOs;

namespace LojaPesca.Application.Interfaces;

public interface IProductService
{
    Task<ProductDto?> GetProductByIdAsync(Guid id);
    Task<IEnumerable<ProductDto>> GetAllProductsAsync();
    Task<IEnumerable<ProductDto>> GetProductsByCategoryAsync(string category);
    Task<IEnumerable<ProductDto>> SearchProductsByNameAsync(string name);
    Task<ProductDto> CreateProductAsync(ProductDto productDto);
    Task UpdateProductAsync(Guid id, ProductDto productDto);
    Task DeleteProductAsync(Guid id);
}
