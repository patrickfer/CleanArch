using CleanArch.Application.DTOs;
using CleanArch.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.WebUI.Controllers
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
            var categories = await _categoryService.GetAllCategories();
            return View(categories);
        }

        public async Task<IActionResult> Details(int? id) 
        {
            if (id is null) return NotFound();

            var categoryDto = await _categoryService.GetById(id);

            if (categoryDto is null) return NotFound(); 

            return View(categoryDto);
        }

        [HttpGet()]
        public async Task<IActionResult> Create()
        { 
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryDTO category)
        {
            if (ModelState.IsValid)
            {
                await _categoryService.Add(category);
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        [HttpGet()]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id is null) return NotFound();

            var categoryVM = await _categoryService.GetById(id);

            if (categoryVM is null) return NotFound();

            return View(categoryVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CategoryDTO categoryDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _categoryService.Update(categoryDto);
                }
                catch (Exception ex) 
                {
                    throw new Exception(ex.Message);
                }
                return RedirectToAction(nameof(Index)); 
            }
            return View(categoryDto);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null) return NotFound();

            var categoryDto = await _categoryService.GetById(id);

            if (categoryDto is null) return NotFound();

            return View(categoryDto);
        }

        [HttpPost(), ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed (int id)
        {
            await _categoryService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
