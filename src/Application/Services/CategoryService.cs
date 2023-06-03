using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryDTO>> GetCategoriesAsync()
        {
            var categoriesEntity = await _categoryRepository.GetCategoriesAsync();
            return _mapper.Map<IEnumerable<CategoryDTO>>(categoriesEntity);
        }

        public async Task<CategoryDTO> GetByIdAsync(string? id)
        {
            var categorieEntity = await _categoryRepository.GetByIdAsync(id);
            return _mapper.Map<CategoryDTO>(categorieEntity);
        }

        public async Task CreateAsync(CategoryDTO categoryDTO)
        {
            var categorieEntity = _mapper.Map<Category>(categoryDTO);
            await _categoryRepository.CreateAsync(categorieEntity);
        }

        public async Task UpdateAsync(CategoryDTO categoryDTO)
        {
            var categorieEntity = _mapper.Map<Category>(categoryDTO);
            await _categoryRepository.RemoveAsync(categorieEntity);
        }

        public async Task RemoveAsync(string? id)
        {
            var categorieEntity = _categoryRepository.GetByIdAsync(id).Result;
            await _categoryRepository.RemoveAsync(categorieEntity);
        }
    }
}