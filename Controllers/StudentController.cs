using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProductApp.DTOs;
using ProductApp.Repositories.Interfaces;
using ProductApp.Services.Interfaces;
using ProductApp.ViewModels;

namespace ProductApp.Controllers;

public class StudentController : Controller
{
    private readonly ICourseRepo _courseRepo;
    private readonly IStudentRepo _studentRepo;
    private readonly IStudentService _studentService;

    // constructor
    public StudentController(IStudentRepo studentRepo, IStudentService studentService, ICourseRepo courseRepo)
    {
        _studentRepo = studentRepo;
        _studentService = studentService;
        _courseRepo = courseRepo;
    }

    // GET: student/index
    public async Task<IActionResult> Index()
    {
        var students = await _studentRepo.GetAllAsync();
        var courses = await _courseRepo.GetAllAsync();

        var studentVms = students.Select(student => new StudentVm
        {
            Id = student.Id,
            Name = student.Name,
            Email = student.Email,
            Address = student.Address,
            CourseId = student.CourseId,
            Courses = courses.Where(course => course.Id == student.CourseId)
                .Select(course => new SelectListItem
                {
                    Value = course.Id.ToString(),
                    Text = course.Title
                }).ToList()
        }).ToList();

        return View(studentVms);
    }

    // GET: student/create
    public async Task<IActionResult> Create()
    {
        var courses = await _courseRepo.GetAllAsync();

        var vm = new StudentCreateVm
        {
            Courses = courses.Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Title
                })
                .ToList()
        };

        return View(vm);
    }

    // POST: student/create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(StudentCreateVm vm)
    {
        if (!ModelState.IsValid)
        {
            // Repopulate dropdown if validation fails
            vm.Courses = (await _courseRepo.GetAllAsync()).Select(course => new SelectListItem
            {
                Value = course.Id.ToString(),
                Text = course.Title
            }).ToList();
            return View(vm);
        }

        var dto = new StudentDto
        {
            Name = vm.Name,
            Email = vm.Email,
            Address = vm.Address,
            CourseId = vm.CourseId
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
            Address = student.Address,
            CourseId = student.CourseId
        };

        return View(vm);
    }

    // POST: student/edit
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(StudentVm vm)
    {
        if (!ModelState.IsValid) return View(vm);

        var dto = new StudentDto
        {
            Id = vm.Id,
            Name = vm.Name,
            Address = vm.Address,
            Email = vm.Email,
            CourseId = vm.CourseId
        };

        await _studentService.UpdateAsync(dto);
        return RedirectToAction(nameof(Index));
    }

    // GET: student/delete
    public async Task<IActionResult> Delete(long id)
    {
        var student = await _studentRepo.GetByIdAsync(id);
        if (student == null) return RedirectToAction(nameof(Index));

        var vm = new StudentVm
        {
            Id = student.Id,
            Name = student.Name,
            Email = student.Email,
            Address = student.Address,
            CourseId = student.CourseId
        };

        return View(vm);
    }

    // POST: student/delete
    [HttpPost]
    [ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(long id)
    {
        await _studentService.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }
}