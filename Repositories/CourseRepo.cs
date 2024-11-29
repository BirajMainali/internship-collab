using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using ProductApp.Data;
using ProductApp.Entities;
using ProductApp.Repositories.Interfaces;

namespace ProductApp.Repositories;

public class CourseRepo : ICourseRepo
{
    private readonly ApplicationDbContext _context;

    public CourseRepo(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Course>> GetAllAsync()
    {
        return await _context.Courses.ToListAsync();
    }

    // Get courses by Id
    public async Task<Course?> GetByIdAsync(long id)
    {
        return await _context.Courses.FirstOrDefaultAsync(c => c.Id == id);
    }
}