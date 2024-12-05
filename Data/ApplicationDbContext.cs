using Microsoft.EntityFrameworkCore;
using ProductApp.Entities;

namespace ProductApp.Data;

public class ApplicationDbContext: DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public DbSet<Membertypes> Membertypes { get; set; }
    public DbSet<Member> Members { get; set; }
}