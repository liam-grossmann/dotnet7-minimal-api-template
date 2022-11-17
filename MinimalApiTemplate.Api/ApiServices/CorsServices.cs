using MinimalApiTemplate.Common;

namespace MinimalApiTemplate.Api.ApiServices;

internal static class CorsServices
{
    internal static void AddCorsServices(this WebApplicationBuilder builder, string corsPolicyName)
    {
        var allowedOrigins =  builder.Configuration[ConfigurationSettings.CorsPolicyWithOrigins]?.Split(' ');
        builder.Services.AddCors(options =>
        {
            options.AddPolicy(corsPolicyName, corsPolicyBuilder =>
            {
                if (allowedOrigins != null)
                {
                    corsPolicyBuilder.WithOrigins(allowedOrigins).AllowAnyMethod().AllowAnyHeader();
                }
            });
        });
    }
}