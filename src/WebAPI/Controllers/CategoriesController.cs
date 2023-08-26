using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var categories = await _categoryService.GetCategoriesAsync();
            if (categories == null)
            {
                return NotFound("Categories not found");
            }
            
            return Ok(categories);
        }

        [HttpGet("{id}", Name = "GetCategory")]
        public async Task<IActionResult> Get(Guid? id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound("category not found");
            }
            
            return Ok(category);
        }

        [HttpPost()]
        public async Task<IActionResult> Post(CategoryDTO category)
        {
            if (category == null) return BadRequest("Invalid Data");
            
            await _categoryService.CreateAsync(category); 

            return new CreatedAtRouteResult("GetCategory", new { Id = category.id}, category);          
        }

        [HttpPut()]
        public async Task<IActionResult> Put(Guid id, CategoryDTO category)
        {
            if (id != category.id) return BadRequest();
            if (category == null) return BadRequest();
            
            await _categoryService.UpdateAsync(category); 

            return Ok(category);          
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var category = await _categoryService.GetByIdAsync(id);

            if (category == null)
                return NotFound("Category is not found");

            await _categoryService.RemoveAsync(id);

            return Ok($"Category: {category.id}, deleted successfully");
        }
    }
}