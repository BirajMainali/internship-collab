﻿using Microsoft.EntityFrameworkCore;
using ProductApp.Data;
using ProductApp.Entities;
using ProductApp.Repositories.Interfaces;

namespace ProductApp.Repositories;

public class StudentRepo : IStudentRepo
{
    private readonly AppDbContext _context;

    public StudentRepo(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Student>> GetAllAsync()
    {
        return await _context.Students.ToListAsync();
    }

    public async Task<Student?> GetByIdAsync(long id)
    {
        return await _context.Students.FirstOrDefaultAsync(s => s.Id == id);
    }
}