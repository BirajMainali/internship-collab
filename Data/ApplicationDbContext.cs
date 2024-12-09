using Microsoft.EntityFrameworkCore;
using ProductApp.Entities;

namespace ProductApp.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    // Dbset
    public  DbSet<Artist> Artists { get; set; }
    public DbSet<Song> Songs { get; set; }
}