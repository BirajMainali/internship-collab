using Microsoft.AspNetCore.Mvc;
using ProductApp.Data;
using ProductApp.Entities;
using ProductApp.Repositories.Interfaces;

namespace ProductApp.Controllers;

public class CourseController : Controller
{
    private readonly ICourseRepo _courseRepo;
    
    // constructor
    public CourseController(ICourseRepo courseRepo)
    {
        _courseRepo = courseRepo;
    }
    
    // Course/Index
    public async Task<IActionResult> Index()
    {
        var courses = await _courseRepo.GetAllAsync();
        return View(courses);
    }
    
    // GET: Course/Create
    public IActionResult Create()
    {
        return View();
    }
    
    // POST: course/create
    [HttpPost]
    public async Task<IActionResult> Create(Course course)
    {
        if (!ModelState.IsValid) return View();

        await _courseRepo.AddAsync(course);
        return RedirectToAction(nameof(Index));
    }
    
    // GET: course/edit
    public async Task<IActionResult> Edit(long id)
    {
        var course = await _courseRepo.GetByIdAsync(id);

        if (course == null) return RedirectToAction(nameof(Index));

        return View(course);
    }
    
    // POST: course/edit
    [HttpPost]
    public async Task<IActionResult> Edit(Course course)
    {
        if (!ModelState.IsValid) return View(course);

        await _courseRepo.UpdateAsync(course);
        return RedirectToAction(nameof(Index));
    }
    
    // GET: course/delete
    public async Task<IActionResult> Delete(long id)
    {
        var course = await _courseRepo.GetByIdAsync(id);
        if (course == null) return RedirectToAction(nameof(Index));
        return View(course);
    }
    
    // POST: course/delete
    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(long id)
    {
        await _courseRepo.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }
    
}







