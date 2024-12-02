using Microsoft.EntityFrameworkCore;
using ProductApp.Entities;

namespace ProductApp.Data;

public class AppDbContext: DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    
    public DbSet<Brand> Brands { get; set; }
    public DbSet<Phone> Phones { get; set; }
}