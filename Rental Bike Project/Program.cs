using Microsoft.EntityFrameworkCore;
using Rental_Bike_Project.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSession(
    options => {
       
        options.Cookie.Name = "Username";
        options.IdleTimeout = TimeSpan.FromMinutes(30); 
        options.Cookie.HttpOnly = true;
        options.Cookie.IsEssential = true;
     
    }
    );

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<MyContext>(options =>
options.UseNpgsql(builder.Configuration.GetConnectionString("DBFirstConnectionString")));



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
    pattern: "{controller=User}/{action=Home}/{id?}");
app.UseSession();
app.Run();
