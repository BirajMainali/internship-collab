using Microsoft.EntityFrameworkCore;
using ProductApp.Data;
using ProductApp.Repositories;
using ProductApp.Repositories.Interfaces;
using ProductApp.Services;
using ProductApp.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ??
                       throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(connectionString));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped <ICategoryService, CategoryService>();
builder.Services.AddScoped <ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped <IFoodService, FoodService>();
builder.Services.AddScoped <IFoodRepository, FoodRepository>();



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