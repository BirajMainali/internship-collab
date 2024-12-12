﻿using Microsoft.AspNetCore.Mvc;
using ProductApp.Dtos;
using ProductApp.DTOs;
using ProductApp.Repositories.Interfaces;
using ProductApp.Services.Interfaces;
using ProductApp.ViewModels;

namespace ProductApp.Controllers;

public class CourseController : Controller
{
    private readonly ICourseRepo _courseRepo;
    private readonly ICourseService _courseService;

    // constructor
    public CourseController(ICourseRepo courseRepo, ICourseService courseService)
    {
        _courseRepo = courseRepo;
        _courseService = courseService;
    }

    // GET: Course/Index
    public async Task<IActionResult> Index()
    {
        var courses = await _courseRepo.GetAllAsync();

        var courseVms = courses.Select(course => new CourseVm
        {
            Id = course.Id,
            Title = course.Title,
            Code = course.Code
        }).ToList();

        return View(courseVms);
    }

    // GET: Course/Create
    public IActionResult Create(string? returnUrl)
    {
        ViewData["ReturnUrl"] = returnUrl;
        return View();
    }

    // POST: course/create
    [HttpPost]
    public async Task<IActionResult> Create(CourseVm vm, string? returnUrl)
    {
        if (!ModelState.IsValid) return View(vm);

        var dto = new CourseDto
        {
            Title = vm.Title,
            Code = vm.Code
        };

        await _courseService.AddAsync(dto);

        // Redirect back if returnUrl is provided; otherwise, go to Course Index
        if (!string.IsNullOrEmpty(returnUrl)) return Redirect(returnUrl);

        return RedirectToAction(nameof(Index));
    }

    // GET: course/edit
    public async Task<IActionResult> Edit(long id)
    {
        var course = await _courseRepo.GetByIdAsync(id);

        var vm = new CourseVm
        {
            Title = course.Title,
            Code = course.Code
        };

        return View(vm);
    }

    // POST: course/edit
    [HttpPost]
    public async Task<IActionResult> Edit(CourseVm vm)
    {
        if (!ModelState.IsValid) return View(vm);

        var dto = new CourseDto
        {
            Title = vm.Title,
            Code = vm.Code
        };

        await _courseService.UpdateAsync(dto);
        return RedirectToAction(nameof(Index));
    }

    // GET: course/delete
    public async Task<IActionResult> Delete(long id)
    {
        var course = await _courseRepo.GetByIdAsync(id);
        return View(course);
    }

    // POST: course/delete
    [HttpPost]
    [ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(long id)
    {
        await _courseService.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }
}