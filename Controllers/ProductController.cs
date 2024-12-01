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

public class ProductController : Controller
{
    public ApplicationDbContext _context;
    public IProductService _productService { get; }
    public IProductRepository _productRepository { get; }
    public ICategoryRepository _categoryRepository { get; }

    public ProductController(
        ApplicationDbContext context,
        IProductService productService,
        IProductRepository productRepository,
        ICategoryRepository categoryRepository
    )
    {
        _context = context;
        _productService = productService;
        _productRepository = productRepository;
        _categoryRepository = categoryRepository;
    }

    public IActionResult Index()
    {
        var dto = _productRepository.GetAll();
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
        var vm = new ProductVm();
        vm.Categories = categories;
        return View(vm);
    }

    [HttpPost]
    public async Task<IActionResult> Create(ProductVm vm)
    {
        if (!ModelState.IsValid) return View(vm);
        var dto = new ProductDto()
        {
            Name = vm.Name,
            Description = vm.Description,
            Price = vm.Price,
            CategoryId = vm.CategoryId
        };
            await _productService.Create(dto);
            return RedirectToAction("Index");
    }


    public IActionResult Edit(long id)
    {
        var dto = _productRepository.GetById(id);
        if (dto == null) return RedirectToAction("Index");
        var categories = _context.Categories.Select(c => new SelectListItem
        {
            Value = c.Id.ToString(),
            Text = c.Name
        }).ToList();

        dto.Categories = categories;

        return View(dto);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(long id, ProductVm vm)
    {
        if (!ModelState.IsValid) return View();

        var dto = new ProductDto
        {
            Id = id,
            Name = vm.Name,
            Description = vm.Description,
            Price = vm.Price,
            CategoryId = vm.CategoryId
        };

        await _productService.Edit(dto);

        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Delete(long id)
    {
        var dto = _productRepository.GetById(id);
        if (dto == null) return RedirectToAction("Index");
        await _productService.Delete(id);
        return RedirectToAction("Index");
    }
}