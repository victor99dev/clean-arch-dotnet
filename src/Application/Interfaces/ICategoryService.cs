using Application.DTOs;

namespace Application.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDTO>> GetCategoriesAsync();
        Task<CategoryDTO> GetByIdAsync(string? id);
        Task CreateAsync(CategoryDTO categoryDTO);
        Task UpdateAsync(CategoryDTO categoryDTO);
        Task RemoveAsync(string? id);
    }
}