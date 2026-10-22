using Academy.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Подключаем существующую базу PV_522_Import.
// База уже содержит таблицы и данные, поэтому EnsureCreated и миграции здесь не вызываются.
builder.Services.AddDbContext<AcademyContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("AcademyContext")
        ?? throw new InvalidOperationException(
            "Connection string 'AcademyContext' not found.")));

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
