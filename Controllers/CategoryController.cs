using Microsoft.AspNetCore.Mvc;
using ProductApp.Dto;
using ProductApp.Models;
using ProductApp.Repositories.Interfaces;
using ProductApp.Services.Interfaces;

namespace ProductApp.Controllers;

public class CategoryController : Controller
{
    public ICategoryService CategoryService { get; }
    public ICategoryRepository _categoryRepository { get; }

    public CategoryController
    (
        ICategoryService categoryService,
        ICategoryRepository categoryRepository
    )
    {
        CategoryService = categoryService;
        _categoryRepository = categoryRepository;
    }

    public IActionResult Index()
    {
        var categories = _categoryRepository.GetAll();
        return View(categories);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(CategoryVm vm)
    {
        if (!ModelState.IsValid) return View();
        var dto = new CategoryDto()
        {
            Name = vm.Name,
            Description = vm.Description
        };
        CategoryService.Create(dto);

        return RedirectToAction("Index");
    }

    public IActionResult Edit(long id)
    {
        var dto = _categoryRepository.GetById(id);
        if (dto == null) return RedirectToAction("Index");
        return View(dto);
    }
    [HttpPost]
    public IActionResult Edit(CategoryDto dto)
    {
        
        CategoryService.Edit(dto);
        return RedirectToAction("Index");
    }
    public IActionResult Delete(long id)
    {
        var dto = _categoryRepository.GetById(id);
        if (dto == null) return RedirectToAction("Index");
        CategoryService.Delete(id);
        return RedirectToAction("Index");
    }
    
    
    
}