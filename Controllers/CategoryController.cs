using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc;
using ProductApp.Dto;
using ProductApp.Models;
using ProductApp.Repositories.Interfaces;
using ProductApp.Services.Interfaces;

namespace ProductApp.Controllers;

public class CategoryController : Controller
{
    private readonly ICategoryService _categoryService;
    private readonly ICategoryRepository _categoryRepository;
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
         var vm = new CategoryEditVm()
         {
             Id = dto.Id,
             Name = dto.Name,
             Description = dto.Description

         };
         return View (vm);
         
     }
    
     [HttpPost]
     public IActionResult Edit(long id, CategoryEditVm vm)
    {
        if (!ModelState.IsValid) return View(vm);
        var category = _categoryRepository.GetById(id);
        if (category == null) return RedirectToAction("Index");
       
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

       if (dto == null)
       {
           TempData["error"] = "Category not found";
           return RedirectToAction("Index");
       }

       try
       {

           _categoryService.Delete(id);
           TempData["success"] = "Category deleted";
       }
       catch (InvalidOperationException ex)
       {
           TempData["error"] = ex.Message;
       }
        return RedirectToAction("Index");
      }
    
}