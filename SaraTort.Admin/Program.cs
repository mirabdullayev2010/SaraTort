using Microsoft.EntityFrameworkCore;
using SaraTort.DAL.Interfaces;
using SaraTort.DAL.Persistence;
using SaraTort.DAL.Repositories;

var builder = WebApplication.CreateBuilder(args);

// 1. Controller va View'larni qo'shish
builder.Services.AddControllersWithViews();

// 2. DbContext ulanishini ro'yxatdan o'tkazish (appsettings.json dagi DefaultConnection orqali)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// 3. UnitOfWork va boshqa Service'larni ro'yxatdan o'tkazish (DbContext'dan pastda bo'lishi shart)
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

var app = builder.Build();

// HTTP so'rovlar quvurini (pipeline) sozlash
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Admin}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();