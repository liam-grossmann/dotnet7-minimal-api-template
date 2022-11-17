using MinimalApiTemplate.Data.Interfaces;
using MinimalApiTemplate.Domain;

namespace MinimalApiTemplate.Api.ApiEndpoints;

public static class ApiUserEndpoints
{
    private const string Tag = "Users";
    private const string BaseRoute = "users";
    
    public static void UseApiUserEndpoints(this WebApplication app)
    {
        app.MapGet(BaseRoute, GetUsersAsync)
            .WithTags(Tag)
            .WithName("GetUsers")
            .WithOpenApi(openApiOperation =>
            {
                openApiOperation.Summary = "Gets a list of users";
                openApiOperation.Description = "Gets a list of users. Supports pagination.";
                return openApiOperation;
            })      
            .Produces<IEnumerable<User>>()
            .AllowAnonymous();

        app.MapGet($"{BaseRoute}/{{code}}", GetUserByCodeAsync)
            .WithTags(Tag)
            .WithName("GetUser")
            .WithOpenApi(openApiOperation =>
            {
                openApiOperation.Summary = "Gets user identified by code";
                openApiOperation.Description = "Returns the user identified by code. If not found, returns 404.";
                return openApiOperation;
            })
            .Produces<User>()
            .Produces(404)
            .AllowAnonymous();
    }
    
    private static async Task<IResult> GetUsersAsync(IUserRepository repository)
    {
        var results = await repository.GetUsersAsync();
        return Results.Ok(results);
    }
    
    private static async Task<IResult> GetUserByCodeAsync(string code, IUserRepository repository)
    {
        var result = await repository.GetUserByCodeAsync(code);
        return result is not null ? Results.Ok(result) : Results.NotFound();
    }
}