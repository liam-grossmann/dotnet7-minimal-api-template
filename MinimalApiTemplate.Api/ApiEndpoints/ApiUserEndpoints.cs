using MinimalApiTemplate.Data.Interfaces;
using MinimalApiTemplate.Domain;

namespace MinimalApiTemplate.Api.ApiEndpoints;

public static class ApiUserEndpoints
{
    public static void UseApiUserEndpoints(this WebApplication app)
    {
        app.MapGet("/users", GetUsersAsync)
            .WithTags("Users")
            .WithOpenApi(openApiOperation =>
            {
                openApiOperation.Summary = "Gets a list of users";
                openApiOperation.Description = "Gets a list of users. Supports pagination.";
                return openApiOperation;
            })      
            .Produces<IEnumerable<User>>()
            .AllowAnonymous();
    }
    
    private static async Task<IResult> GetUsersAsync(IUserRepository repository)
    {
        var results = await repository.GetUsersAsync();
        return Results.Ok(results);
    }
}