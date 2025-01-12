using Microsoft.EntityFrameworkCore;
using PersonalWebsite.Models;
using PersonalWebsite.Middleware;

var builder = WebApplication.CreateBuilder(args);

//Add services to the container.
builder.Services.AddControllersWithViews();

//Set up DB
string connectionString = "Data Source=Database.sqlite;Cache=Shared;";
builder.Services.AddDbContext<DBContext>(options => options.UseSqlite(connectionString));

//Set up stats DB
string statsConnectionString = "Data Source=StatsDatabase.sqlite;Cache=Shared;";
builder.Services.AddDbContext<StatsDBContext>(options => options.UseSqlite(statsConnectionString));

var app = builder.Build();

//Configure the HTTP request pipeline.
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

//Configure middleware for page logging
app.UseMiddleware<PageLogging>();

app.Run();
