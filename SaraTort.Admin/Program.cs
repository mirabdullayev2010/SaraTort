using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using SaraTort.DAL.Interfaces;
using SaraTort.DAL.Persistence;
using SaraTort.DAL.Repositories;

var builder = WebApplication.CreateBuilder(args);

// 1. Controller va View'larni qo'shish
builder.Services.AddControllersWithViews();

// 2. DbContext ulanishini ro'yxatdan o'tkazish
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// 3. UnitOfWork va boshqa Service'larni ro'yxatdan o'tkazish
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// 4. COOKIE AUTHENTICATION'NI QO'SHISH (Yangi qo'shilgan qism)
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Admin/Login";       // Tizimga kirmagan bo'lsa avto shu yo'lga otadi
        options.AccessDeniedPath = "/Admin/Login"; // Huquqi yetmasa ham loginga otadi
        options.ExpireTimeSpan = TimeSpan.FromDays(7); // "Eslab qolish" muddati (7 kun)
    });

var app = builder.Build();

// HTTP so'rovlar quvurini (pipeline) sozlash
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

// Statik fayllar (CSS, JS, Images)
app.MapStaticAssets();

app.UseRouting();

// 5. AUTHENTICATION VA AUTHORIZATION (Ketma-ketlik o'ta muhim!)
// DIQQAT: UseAuthentication albatta UseRouting'dan keyin va UseAuthorization'dan OLDIN turishi shart!
app.UseAuthentication();
app.UseAuthorization();

// Yo'nalishlar (Routes)
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Admin}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();