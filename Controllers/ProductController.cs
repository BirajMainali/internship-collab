using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProductApp.Data;
using ProductApp.Entities;
using ProductApp.Models;

namespace ProductApp.Controllers;

public class ProductController : Controller
{
    public ApplicationDbContext _context;

    public ProductController(ApplicationDbContext context)
    {
        _context = context;
    }
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Create()
    {
        var categories = _context.Categories.Select(c => new SelectListItem
        {
            Value = c.Id.ToString(),
            Text = c.Name
        }).ToList();
        categories.Insert(0, new SelectListItem
        {
            Value = "",
            Text = "None",
            Selected = true
        });

        ViewBag.Categories = categories;
        return View();
    }
}