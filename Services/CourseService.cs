using ProductApp.Data;
using ProductApp.Dtos;
using ProductApp.DTOs;
using ProductApp.Entities;
using ProductApp.Services.Interfaces;

namespace ProductApp.Services;

public class CourseService : ICourseService
{
    private readonly AppDbContext _context;

    public CourseService(AppDbContext context)
    {
        _context = context;
    }

    // Create course
    public async Task AddAsync(CourseDto dto)
    {
        var course = new Course
        {
            Title = dto.Title,
            Code = dto.Code
        };

        _context.Courses.Add(course);
        await _context.SaveChangesAsync();
    }

    // Edit course
    public async Task UpdateAsync(CourseDto dto)
    {
        var course = await _context.Courses.FindAsync(dto.Id);

        if (course != null)
        {
            course.Title = dto.Title;
            course.Code = dto.Code;

            _context.Courses.Update(course);
            await _context.SaveChangesAsync();
        }
    }

    // Delete course
    public async Task DeleteAsync(long id)
    {
        var course = await _context.Courses.FindAsync(id);

        if (course != null)
        {
            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
        }
    }
}