using System.Net;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using MinimalApiTemplate.Api.ApiFilters;
using MinimalApiTemplate.Data.Interfaces;
using MinimalApiTemplate.Domain;

namespace MinimalApiTemplate.Api.ApiEndpoints;

public static class ApiUserEndpoints
{
    private const string Tag = "Users";
    private const string BaseRoute = "users";
    
    public static void UseApiUserEndpoints(this RouteGroupBuilder route)
    {
        route.MapGet(BaseRoute, GetUsersAsync)
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

        route.MapGet($"{BaseRoute}/{{code}}", GetUserByCodeAsync)
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

        route.MapPost(BaseRoute, RegisterUser)
            .WithTags(Tag)
            .WithName("RegisterUser")
            .WithOpenApi(openApiOperation =>
            {
                openApiOperation.Summary = "Registers a new user";
                openApiOperation.Description = "Registers a new user and returns the details of the newly added record";
                return openApiOperation;
            })
            .Produces<User>()
            .Produces(422);
        // .AddEndpointFilter<ValidationFilter<RegisterUserRequestModel>>();;
        
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

    private static async Task<IResult> RegisterUser([Validate] RegisterUserRequestModel requestModel)
    {
        return Results.Ok();
    }
}