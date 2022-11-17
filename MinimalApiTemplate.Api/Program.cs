using MinimalApiTemplate.Api.ApiEndpoints;
using MinimalApiTemplate.Api.ApiServices;
using MinimalApiTemplate.Data;

namespace MinimalApiTemplate.Api;

public class Program
{
    
    private const string CorsPolicyName = "CorsPolicy";
    
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.AddSwaggerServices();
        builder.AddCorsServices(CorsPolicyName);
        builder.Services.RegisterApplicationServices();

        var app = builder.Build();

       // if (app.Environment.IsDevelopment())
       // {
            app.UseSwagger();
            app.UseSwaggerUI();
       // }

       app.UseCors(CorsPolicyName);
       app.UseHttpsRedirection();
       app.UseHsts();



        app.UseApiEndpoints();

        app.Run();
    }
}