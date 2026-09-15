using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MyAcademy.Components;
using MyAcademy.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

//правка
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found."); //получаем строку подключения из appseting.json

builder.Services.AddDbContextFactory<MyAcademyContext>(options =>
    options.UseSqlServer(connectionString)); //Добавляет в контейнер сервисов builder.Services фабрику контекста базы

builder.Services.AddQuickGridEntityFrameworkAdapter();

builder.Services.AddDatabaseDeveloperPageExceptionFilter();
                                             //AddDbContextFactory<MyAcademyContext>(options => options.UseSqlServer(connectionString))

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    app.UseMigrationsEndPoint();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
