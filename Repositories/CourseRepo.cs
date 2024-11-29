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

    public async Task<IEnumerable<Course>> GetAllAsync()
    {
        return await _context.Courses.ToListAsync();
    }

    // Get courses by Id
    public async Task<Course?> GetByIdAsync(long id)
    {
        return await _context.Courses.FirstOrDefaultAsync(c => c.Id == id);
    }
    
    // Create courses
    public async Task AddAsync(Course course)
    {
        _context.Courses.Add(course);
        await _context.SaveChangesAsync();
    }
    
    // Update courses
    public async Task UpdateAsync(Course course)
    {
        _context.Courses.Update(course);
        await _context.SaveChangesAsync();
    }
    
    // Delete courses
    public async Task DeleteAsync(long id)
    {
        var course = await GetByIdAsync(id);

        if (course != null)
        {
            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
        }
    }
}