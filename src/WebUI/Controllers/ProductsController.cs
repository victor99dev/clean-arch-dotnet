using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebUI.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        public ProductsController(
            IProductService productService,
            ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetProductsAsync();
            return View(products);
        }

        [HttpGet()]
        public async Task<IActionResult> Create()
        {
            ViewBag.CategoryId = new SelectList(
                await _categoryService.GetCategoriesAsync(),
                "id", "name");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductDTO product)
        {
            if (ModelState.IsValid)
            {
                await _productService.CreateAsync(product);
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        [HttpGet()]
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null) return NotFound();

            var product = await _productService.GetByIdAsync(id);

            if (product == null) return NotFound();

            var categories = await _categoryService.GetCategoriesAsync();

            ViewBag.CategoryId = new SelectList(categories, "id", "name", product.category_id);

            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductDTO product)
        {
            if (ModelState.IsValid)
            {
                await _productService.UpdateAsync(product);
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

    }
}