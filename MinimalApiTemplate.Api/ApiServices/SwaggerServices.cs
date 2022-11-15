using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace MinimalApiTemplate.Api.ApiServices;

internal static class SwaggerServices
{
    private const string ApiVersionName = "v1";
    private const string ApiVersionNumber = "1.0.0.001";

    /// <summary>
    /// Add swagger options including JWT bearer token support, xml documentation support, and swagger top level
    /// documentation including version number, title, author etc. 
    /// </summary>
    internal static void AddSwaggerServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(setup =>
        {
            setup.AddSecurityDefinition("Bearer", GetOpenApiSecurityScheme());
            setup.AddSecurityRequirement(GetOpenApiSecurityRequirement());
            setup.SwaggerDoc(ApiVersionName, GetOpenApiInfo(ApiVersionNumber));
            setup.AddXmlDocumentation();
        });
    }

    private static void AddXmlDocumentation(this SwaggerGenOptions setup)
    {
        string[] xmlFiles = {"MinimalApiTemplate.Domain.xml",  "MinimalApiTemplate.Api.xml"};
        foreach (var file in xmlFiles)
        {
            setup.AddXmlDocument(file);
        }
    }

    private static void AddXmlDocument(this SwaggerGenOptions setup, string fileName)
    {
        var filenameWithPath = Path.Combine(AppContext.BaseDirectory, fileName);
        if (File.Exists(filenameWithPath))
        {
            setup.IncludeXmlComments(filenameWithPath, true);
        }
    }

    private static OpenApiSecurityScheme GetOpenApiSecurityScheme()
    {
        return new OpenApiSecurityScheme
        {
            Scheme = "Bearer",
            BearerFormat = "JWT",
            In = ParameterLocation.Header,
            Name = "Authorization",
            Description = "Bearer Authentication with JWT Token",
            Type = SecuritySchemeType.Http
        };
    }

    private static OpenApiSecurityRequirement GetOpenApiSecurityRequirement()
    {
        return new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Id = "Bearer",
                        Type = ReferenceType.SecurityScheme
                    }
                },
                new List<string>()
            }
        };
    }

    private static OpenApiInfo GetOpenApiInfo(string apiVersionNumber)
    {
        return new OpenApiInfo
        {
            Description = "Api implementation using Minimal Api in Asp.Net Core 7.0",
            Title = "Minimal Api",
            Version = apiVersionNumber,
            Contact = new OpenApiContact()
            {
                Name = "Liam Grossmann",
                Url = new Uri("https://github.com/liam-grossmann")
            }
        };
    }
}