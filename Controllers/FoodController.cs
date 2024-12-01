using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProductApp.Data;
using ProductApp.Dto;
using ProductApp.Entities;
using ProductApp.Models;
using ProductApp.Repositories.Interfaces;
using ProductApp.Services.Interfaces;

namespace ProductApp.Controllers;

public class FoodController : Controller
{
    public IFoodService _foodService { get; }
    public IFoodRepository _FoodRepository { get; }
    public ICategoryRepository _categoryRepository { get; }
    public ApplicationDbContext _context;

    public FoodController(
        ApplicationDbContext context,
        IFoodService foodService, 
        IFoodRepository foodRepository,
        ICategoryRepository categoryRepository
        )
    {
        _foodService = foodService;
        _FoodRepository = foodRepository;
        _categoryRepository = categoryRepository;
        _context = context;
    }

    public IActionResult Index()
    {
        var dto = _FoodRepository.GetAll();
        var categories = _categoryRepository.GetAll();
        var categoryLookup = categories.ToDictionary(c => c.Id, c => c.Name);
        ViewBag.CategoryLookup = categoryLookup;
        return View(dto);
    }

    public IActionResult Create()
    {
        var categories = _context.Categories.Select(c => new SelectListItem
        {
            Value = c.Id.ToString(),
            Text = c.Name
        }).ToList();
        var vm = new FoodVm();
        vm.Categories = categories;
        return View(vm);
    }

    [HttpPost]
    public IActionResult Create(FoodVm vm)
    {
        if(!ModelState.IsValid)return View();
        var dto = new FoodDto()
        {
            Name = vm.Name,
            Price = vm.Price,
            Description = vm.Description,
            CategoryId = vm.CategoryId
        };
        _foodService.Create(dto);
        return RedirectToAction("Index");
    }

    public decimal Price { get; set; }

    public long Name { get; set; }

    public IActionResult Edit(int id)
    {
        var dto = _FoodRepository.GetById(id);
        if(dto == null)return RedirectToAction("Index");
        var categories = _context.Categories.Select(c => new SelectListItem
        {
            Value = c.Id.ToString(),
            Text = c.Name
        }).ToList();

        dto.Categories = categories;
        return View(dto);
    }

    [HttpPost]
    public IActionResult Edit( long id, FoodVm vm)
    {
        var dto = new FoodDto()
        {
            Id = id,
            Name = vm.Name,
            Price = vm.Price,

            Description = vm.Description,
            CategoryId = vm.CategoryId
        };
        
        _foodService.Edit(dto);
        return RedirectToAction("Index");

    }

    public long Id { get; set; }

    public long CategoryId { get; set; }

    public string Description { get; set; }

    public IActionResult Delete(long id)
    {
        var dto = _FoodRepository.GetById(id);
        if (dto == null) return RedirectToAction("Index");
        _foodService.Delete(id);
        return RedirectToAction("Index");
    }

}

    