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
    private readonly IProductService _productService;
    private readonly IProductRepository _productRepository;
    private readonly ICategoryRepository _categoryRepository;

    public ProductController(
        IProductService productService,
        IProductRepository productRepository,
        ICategoryRepository categoryRepository
    )
    {
        _productService = productService;
        _productRepository = productRepository;
        _categoryRepository = categoryRepository;
    }
    
    //display all product from DB 
    public IActionResult Index()
    {
        var products = _productRepository.GetQueryable();
        var vm = products.Select(product => new ProductListVm
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
            Description = product.Description,
            CategoryId = product.CategoryId,
            CategoryName = product.Category.Name,
        }).ToList();

        return View(vm);
    }

    //provide view to add product
    public IActionResult Create()
    {
        var vm = new ProductVm();
        vm.Categories = _categoryRepository.GetCategories();
        return View(vm);
    }
    
    //Add product to DB
    [HttpPost]
    public async Task<IActionResult> Create(ProductVm vm)
    {
        if (!ModelState.IsValid)
        {
            vm.Categories = _categoryRepository.GetCategories();
            return View(vm);
        }
        var dto = new ProductDto()
        {                                                     
            Name = vm.Name,
            Description = vm.Description,
            Price = vm.Price,
            CategoryId = (int)vm.CategoryId
        };
            await _productService.Create(dto);
            return RedirectToAction("Index");
    }


    public IActionResult Edit(long id)
    {
        var dto = _productRepository.GetById(id);
        if (dto == null) return RedirectToAction("Index");
        var categories = _categoryRepository.GetCategories();
        var vm = new ProductEditVm()
        {
            Id = dto.Id,
            Name = dto.Name,
            Description = dto.Description,
            CategoryId = dto.CategoryId,
            Price = dto.Price,
            Categories = categories

        };
        

        return View(vm);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(long id, ProductEditVm vm)
    {
        

        if (!ModelState.IsValid)
        {
            vm.Categories = _categoryRepository.GetCategories();
            return View(vm);
        }
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