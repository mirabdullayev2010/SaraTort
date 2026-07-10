using Microsoft.EntityFrameworkCore;
using SaraTort.DAL.Persistence;
using SaraTort.DAL.Interfaces;
using SaraTort.DAL.Repositories;
using SaraTort.API.Configuration;
using SaraTort.API.Configuration;
var builder = WebApplication.CreateBuilder(args);

// Ma'lumotlar bazasi ulanishi
var connectionString = builder.Configuration.GetConnectionString("localhost");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString));

// Servislar va konfiguratsiyalarni zanjirsimon ulash
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services
    .AddControllers();

builder.Services
    .AddOptionConfiguration(builder.Configuration) // <-- DOMIANGIZNING USLUBIDA OPTIONLAR QO'SHILDI
    .AddOpenApi();

var app = builder.Build();

// HTTP so'rovlar quvurini (pipeline) sozlash
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();