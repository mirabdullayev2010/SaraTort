    
using SaraTort.Shared.Options;

namespace SaraTort.API.Configuration;

public static class OptionConfiguration
{
    public static IServiceCollection AddOptionConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        // appsettings.json ichidagi asosiy bo'limni olamiz
        var settings = configuration.GetSection("SaraTortSettings");

        // Products papkasidagi optionlar
        services.Configure<CakeOption>(settings.GetSection(nameof(CakeOption)));
        services.Configure<CakeReviewOption>(settings.GetSection(nameof(CakeReviewOption)));
        services.Configure<CategoryOption>(settings.GetSection(nameof(CategoryOption)));

        // Orders papkasidagi optionlar
        services.Configure<CartItemOption>(settings.GetSection(nameof(CartItemOption)));
        services.Configure<OrderOption>(settings.GetSection(nameof(OrderOption)));
        services.Configure<OrderItemOption>(settings.GetSection(nameof(OrderItemOption)));

        // Users papkasidagi optionlar
        services.Configure<UserOption>(settings.GetSection(nameof(UserOption)));

        return services;
    }
}