using HotelSystem.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<HotelSysDBContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("HotelSysDBConnection")));

//�ƻs���� HotelSysDBContext 2�ݭn�s�W���U
builder.Services.AddDbContext<HotelSysDBContext2>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("HotelSysDB2Connection")));


//////////////////////////////////////////////////////////////

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
