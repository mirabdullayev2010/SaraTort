using Microsoft.EntityFrameworkCore;
using SaraTort.DAL.Persistence;

var builder = WebApplication.CreateBuilder(args);

// 1. Appsettings.json ichidan siz yozgan "localhost" ulanish kodini o'qib olish
var connectionString = builder.Configuration.GetConnectionString("localhost");

// 2. DbContext-ni PostgreSQL drayveri bilan loyihaga ulash
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString));

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapibuilder
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

builder.Services.AddControllers();

app.MapControllers();

app.Run();