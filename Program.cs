using Zhenic.Models;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Zhenic.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();



// Here lies my Code Peacfully
// 

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite(
    builder.Configuration.GetConnectionString("DefaultConnection")
));

builder.Services.AddScoped<IArchiveRepository, ArchiveRepository>();

builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
builder.Services.AddTransient<IValidator<ArchiveViewModel>, ArchiveViewModelValidator>();

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
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.MapControllerRoute(
    name: "people",
    pattern: "People/{controller=People}/{action=Index}/{id?}"
);

app.MapControllerRoute(
    name: "archive",
    pattern: "Archive/{action=Index}/{id?}"
);

app.Run();
