using FilmDB.Data;
using FilmDB.logic;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

LoggerFactory _myLoggerFactory =
    new LoggerFactory(new[] {
                new Microsoft.Extensions.Logging.Debug.DebugLoggerProvider()
    });

// Add services to the container.
builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<FilmContext>(options =>
    options
    .UseSqlServer(connectionString)
    .UseLoggerFactory(_myLoggerFactory)
    .EnableSensitiveDataLogging());

builder.Services.AddScoped<FilmManager>();

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
    pattern: "{controller=Film}/{action=Index}/{id?}");

app.Run();
