using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.OpenApi;
using System.Text;

namespace SaraTort.API.Configuration;

public static class AuthConfiguration
{
    // 1. CORS sozlamasi
    public static IServiceCollection AddCorsConfiguration(this IServiceCollection services)
        => services.AddCors(o => o.AddPolicy(
                name: "AllowAll",
                policy => policy
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()));

    // 2. .NET 9 dagi OpenApi uchun JWT Tugmasini sozlash (Xatosiz variant)
    public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services)
    {
        services.ConfigureOpenApi(options =>
        {
            options.AddDocumentTransformer((document, context, cancellationToken) =>
            {
                var requirement = new OpenApiSecurityRequirement
                {
                    [new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    }] = Array.Empty<string>()
                };
                document.SecurityRequirements.Add(requirement);
                return Task.CompletedTask;
            });
        });

        return services;
    }

    // 3. JWT sozlamasi
    public static IServiceCollection AddJwtConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication(x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(o =>
        {
            var secretKey = configuration["JWT:Secret"] ?? "SizningMaxfiyKalitingizKamida32TaBelgiBolishiKerek";
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