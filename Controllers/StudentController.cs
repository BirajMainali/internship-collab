using Microsoft.AspNetCore.Mvc;
using ProductApp.Entities;
using ProductApp.Repositories.Interfaces;

namespace ProductApp.Controllers;

public class StudentController : Controller
{
    private readonly IStudentRepo _studentRepo;

    // constructor
    public StudentController(IStudentRepo studentRepo)
    {
        _studentRepo = studentRepo;
    }
    
    // GET: student/index
    public async Task<IActionResult> Index()
    {
        var students = await _studentRepo.GetAllAsync();
        return View(students);
    }
    
    // GET: student/create
    public IActionResult Create()
    {
        return View();
    }
    
    // POST: student/course
    public async Task<IActionResult> Create(Student student)
    {
        await _studentRepo.AddAsync(student);
        return RedirectToAction(nameof(Index));
    }
}