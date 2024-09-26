using CleanArch.Application.DTOs;
using CleanArch.Application.Interfaces;
using CleanArch.Application.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace CleanArch.WebUI.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IWebHostEnvironment _env;
        public ProductsController(IProductService productService, ICategoryService categoryService, IWebHostEnvironment env)
        {
            _productService = productService;
            _categoryService = categoryService;
            _env = env;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var categories = await _productService.GetAllProducts();
            return View(categories);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id is null) return NotFound();

            var productDto = await _productService.GetById(id);

            if (productDto is null) return NotFound();

            var wwwroot = _env.WebRootPath;
            var image = Path.Combine(wwwroot, "images\\" + productDto.Image);
            var exists = System.IO.File.Exists(image);
            ViewBag.ImageExist = exists;

            return View(productDto);
        }

        [HttpGet()]
        public async Task<IActionResult> Create()
        {
            ViewBag.CategoryId = 
                new SelectList(await  _categoryService.GetAllCategories(), "Id", "Name");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductDTO product)
        {
            if (ModelState.IsValid)
            {
                await _productService.Add(product);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ViewBag.CategoryId =
                            new SelectList(await _categoryService.GetAllCategories(), "Id", "Name");
            }
            return View(product);
        }

        [HttpGet()]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id is null) return NotFound();

            var productVM = await _productService.GetById(id);

            if (productVM is null) return NotFound();

            ViewBag.CategoryId =
               new SelectList(await _categoryService.GetAllCategories(), "Id", "Name");

            return View(productVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductDTO productDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _productService.Update(productDto);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ViewBag.CategoryId =
              new SelectList(await _categoryService.GetAllCategories(), "Id", "Name");
            }
            return View(productDto);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null) return NotFound();

            var productDto = await _productService.GetById(id);

            if (productDto is null) return NotFound();

            return View(productDto);
        }

        [HttpPost(), ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _productService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
