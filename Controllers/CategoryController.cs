using Microsoft.AspNetCore.Mvc;
using ProductApp.Dto;
using ProductApp.Models;
using ProductApp.Repositories.Interfaces;
using ProductApp.Services.Interfaces;

namespace ProductApp.Controllers;

public class CategoryController : Controller
{
    public ICategoryService _categoryService { get; }
    public ICategoryRepository _categoryRepository { get; }

    public CategoryController(ICategoryService categoryService,ICategoryRepository categoryRepository)
    {
        _categoryService = categoryService;
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
        _categoryService.Create(dto);
        return RedirectToAction("Create");
    }

     public IActionResult Edit(long id)
     {
         var dto = _categoryRepository.GetById(id);
         if (dto == null) return RedirectToAction("Index");
         return View (dto);
         
     }
    
     [HttpPost]
     public IActionResult Edit(long id, CategoryVm vm)
    {
       
         var dto = new CategoryDto()
         {
            Id = id,
            Name = vm.Name,
             Description = vm.Description
         };
        _categoryService.Edit(dto);
         return RedirectToAction("Index");
     }
    
     public IActionResult Delete(long id)
     {
       var dto = _categoryRepository.GetById(id);
       if (dto == null) return RedirectToAction("Index");
       _categoryService.Delete(id);
        return RedirectToAction("Index");
      }
    
}