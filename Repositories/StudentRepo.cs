using Microsoft.EntityFrameworkCore;
using ProductApp.Data;
using ProductApp.Entities;
using ProductApp.Repositories.Interfaces;

namespace ProductApp.Repositories;

public class StudentRepo : IStudentRepo
{
    private readonly ApplicationDbContext _context;

    public StudentRepo(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Student>> GetAllAsync()
    {
        return await _context.Students.ToListAsync();
    }

   
    public async Task<Student?> GetByIdAsync(long id)
    {
        return await _context.Students.FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task AddAsync(Student student)
    {
        _context.Students.Add(student);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Student student)
    {
        _context.Students.Update(student);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(long id)
    {
        var student = await GetByIdAsync(id);
        if (student != null)
        {
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
        }
    }
}