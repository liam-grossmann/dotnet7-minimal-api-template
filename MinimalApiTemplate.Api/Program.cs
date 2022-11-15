using MinimalApiTemplate.Api.ApiServices;
using MinimalApiTemplate.Data;

namespace MinimalApiTemplate.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.AddSwaggerServices();

        var app = builder.Build();

       // if (app.Environment.IsDevelopment())
       // {
            app.UseSwagger();
            app.UseSwaggerUI();
       // }


        app.MapGet("/", () => "Hello World!")
            .WithTags("Test")
            .WithOpenApi(openApiOperation =>
            {
                openApiOperation.Summary = "Home api call";
                openApiOperation.Description = "Displays hello world";
                return openApiOperation;
            })
            .AllowAnonymous();

        app.MapGet("/users", () => new UserRepository().GetUsers())
            .WithTags("Users")
            .WithOpenApi(openApiOperation =>
            {
                openApiOperation.Summary = "Gets a list of users";
                openApiOperation.Description = "Gets a list of users. Support pagination.";
                return openApiOperation;
            })
            .AllowAnonymous();


        app.Run();
    }
}