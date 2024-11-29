using Microsoft.AspNetCore.Mvc;
using ProductApp.DTOs;
using ProductApp.Repositories.Interfaces;
using ProductApp.Services.Interfaces;
using ProductApp.ViewModels;

namespace ProductApp.Controllers;

public class StudentController : Controller
{
    private readonly IStudentRepo _studentRepo;
    private readonly IStudentService _studentService;

    // constructor
    public StudentController(IStudentRepo studentRepo, IStudentService studentService)
    {
        _studentRepo = studentRepo;
        _studentService = studentService;
    }

    // GET: student/index
    public async Task<IActionResult> Index()
    {
        var students = await _studentRepo.GetAllAsync();

        var studentVms = students.Select(student => new StudentVm
        {
            Id = student.Id,
            Name = student.Name,
            Email = student.Email,
            Address = student.Address
        }).ToList();

        return View(studentVms);
    }

    // GET: student/create
    public IActionResult Create()
    {
        return View();
    }

    // POST: student/create
    [HttpPost]
    public async Task<IActionResult> Create(StudentVm vm)
    {
        if (!ModelState.IsValid) return View(vm);

        var dto = new StudentDto
        {
            Id = vm.Id,
            Name = vm.Name,
            Email = vm.Email,
            Address = vm.Address
        };

        await _studentService.AddAsync(dto);
        return RedirectToAction(nameof(Index));
    }

    // GET: student/edit
    public async Task<IActionResult> Edit(long id)
    {
        var student = await _studentRepo.GetByIdAsync(id);
        if (student == null) return RedirectToAction(nameof(Index));

        var vm = new StudentVm
        {
            Id = student.Id,
            Name = student.Name,
            Email = student.Email,
            Address = student.Address
        };

        return View(vm);
    }

    // POST: student/edit
    [HttpPost]
    public async Task<IActionResult> Edit(StudentVm vm)
    {
        if (!ModelState.IsValid) return View(vm);

        var dto = new StudentDto
        {
            Id = vm.Id,
            Name = vm.Name,
            Address = vm.Address,
            Email = vm.Email
        };

        await _studentService.UpdateAsync(dto);
        return RedirectToAction(nameof(Index));
    }

    // GET: student/delete
    public async Task<IActionResult> Delete(long id)
    {
        var student = await _studentRepo.GetByIdAsync(id);
        if (student == null) return RedirectToAction(nameof(Index));

        return View(student);
    }

    // POST: student/edit
    [HttpPost]
    [ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(long id)
    {
        await _studentService.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }
}