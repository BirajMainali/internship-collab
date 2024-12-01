using Microsoft.EntityFrameworkCore;
using ProductApp.Entities;

namespace ProductApp.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    // for student app
    public DbSet<Student> Students { get; set; }
    public DbSet<Course> Courses { get; set; }
}