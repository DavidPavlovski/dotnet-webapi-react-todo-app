using Microsoft.EntityFrameworkCore;
using TodoWebApp.DataAccess;
using TodoWebApp.DataAccess.Abstracion;
using TodoWebApp.DataAccess.Repositories;
using TodoWebApp.Domain;
using TodoWebApp.Services.Abstraction;
using TodoWebApp.Services.Implementation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddTransient<ITodoService, TodoService>();
builder.Services.AddTransient<IRepository<Todo>, TodoRepository>();

builder.Services.AddDbContext<TodoWebAppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
