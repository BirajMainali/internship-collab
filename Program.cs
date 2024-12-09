using Microsoft.EntityFrameworkCore;
using ProductApp.Data;
using ProductApp.Repositories;
using ProductApp.Repositories.Interfaces;
using ProductApp.Services;
using ProductApp.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Database connection
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ??
                       throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));

// Add services and repositories
builder.Services.AddScoped<ArtistRepo>();
builder.Services.AddScoped<ArtistService>();
builder.Services.AddScoped<SongRepo>();
builder.Services.AddScoped<SongService>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();