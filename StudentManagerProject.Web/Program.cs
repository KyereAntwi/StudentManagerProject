using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StudentManagerProject.Web.Data;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DbContextConnection") ?? throw new InvalidOperationException("Connection string 'ApplicationDbContextConnection' not found.");

// services

builder.Services.AddRazorPages();

builder.Services.AddDbContext<ApplicationDbContext>(options => 
{
    options.UseSqlite(connectionString);
});
builder.Services.AddDefaultIdentity<IdentityUser>(
    options => {
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireUppercase = false;
        options.Password.RequireLowercase = false;
        options.Password.RequiredLength = 6;
    }).AddEntityFrameworkStores<ApplicationDbContext>();

var app = builder.Build();

// middlewares

app.MapRazorPages();

app.Run();
