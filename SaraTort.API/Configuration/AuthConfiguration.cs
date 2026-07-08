using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi;
using System.Text;

namespace SaraTort.API.Configurations;

public static class AuthConfiguration
{
    public static IServiceCollection AddCorsConfiguration(
        this IServiceCollection services)
        => services.AddCors(o
            => o.AddPolicy(
                name: "AllowAll",
                policy => policy
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()));

    public static IServiceCollection AddSwaggerConfiguration(
        this IServiceCollection services)
        => services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc(
                name: "v1",
                info: new OpenApiInfo // Endi xato bermaydi
                {
                    Title = "Smart Restaurant Api",
                    Version = "v1"
                });

            c.AddSecurityDefinition(
                name: "Bearer",
                securityScheme: new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Description = "Jwt Authorization header using the Bearer scheme.",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] { }
                }
            });

            c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
        });

    public static IServiceCollection AddJwtConfiguration(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddAuthentication(x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(o =>
        {
            var secretKey = configuration["JWT:Secret"] ?? "SizningMaxfiyKalitingizKamida16TaBelgiBo'lishiKerek";
            var key = Encoding.UTF8.GetBytes(secretKey);

            o.SaveToken = true;
            o.RequireHttpsMetadata = false;
            o.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = configuration["JWT:Issuer"],
                ValidAudience = configuration["JWT:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ClockSkew = TimeSpan.FromMinutes(5)
            };
        });

        return services;
    }
}