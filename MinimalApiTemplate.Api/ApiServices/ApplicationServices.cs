using MinimalApiTemplate.Data;
using MinimalApiTemplate.Data.Interfaces;

namespace MinimalApiTemplate.Api.ApiServices;

internal static class ApplicationServices
{
    internal static void RegisterApplicationServices(this IServiceCollection services)
    {
        // Registers the httpClientFactory which is required by LinkPreview
        services.AddHttpClient();
        
        services.AddSingleton<IUserRepository, UserRepository>();
    }
}