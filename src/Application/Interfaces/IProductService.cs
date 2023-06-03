using Application.DTOs;

namespace Application.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetProductsAsync();
        Task<ProductDTO> GetByIdAsync(string? id);
        Task<ProductDTO> GetProductCategoryAsync(string? id);
        Task CreateAsync(ProductDTO productDTO);
        Task UpdateAsync(ProductDTO productDTO);
        Task RemoveAsync(string? id);
    }
}