using ProductApp.Data;
using ProductApp.DTOs;
using ProductApp.Entities;
using ProductApp.Services.Interfaces;

namespace ProductApp.Services;

public class StudentService : IStudentService
{
    private readonly AppDbContext _context;

    public StudentService(AppDbContext context)
    {
        _context = context;
    }

    // create student
    public async Task AddAsync(StudentDto dto)
    {
        var student = new Student
        {
            Name = dto.Name,
            Email = dto.Email,
            Address = dto.Address,
            CourseId = dto.CourseId
        };

        _context.Students.Add(student);
        await _context.SaveChangesAsync();
    }

    // edit student
    public async Task UpdateAsync(StudentDto dto)
    {
        var student = await _context.Students.FindAsync(dto.Id);

        if (student != null)
        {
            student.Name = dto.Name;
            student.Email = dto.Email;
            student.Address = dto.Address;
            student.CourseId = dto.CourseId;

            _context.Students.Update(student);
            await _context.SaveChangesAsync();
        }
    }

    // delete student
    public async Task DeleteAsync(long id)
    {
        var student = await _context.Students.FindAsync(id);
        if (student != null)
        {
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
        }
    }
}