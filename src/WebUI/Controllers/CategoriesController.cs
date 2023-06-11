using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetCategoriesAsync();
            return View(categories);
        }

        [HttpGet()]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryDTO category)
        {
            if (ModelState.IsValid)
            {
                await _categoryService.CreateAsync(category);
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        [HttpGet()]
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null) return NotFound();

            var category = await _categoryService.GetByIdAsync(id);

            if (category == null) return NotFound();

            return View(category);
        }

        [HttpPost()]
        public async Task<IActionResult> Edit(CategoryDTO category)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _categoryService.UpdateAsync(category);
                }
                catch (Exception)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        [HttpGet()]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null) return NotFound();

            var category = await _categoryService.GetByIdAsync(id);

            if (category == null) return NotFound();

            return View(category);
        }

        [HttpPost(), ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(Guid? id)
        {
            await _categoryService.RemoveAsync(id);
            return RedirectToAction("Index");
        }

        [HttpGet()]
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null) return NotFound();

            var category = await _categoryService.GetByIdAsync(id);

            if (category == null) return NotFound();

            return View(category);
        }
    }
}