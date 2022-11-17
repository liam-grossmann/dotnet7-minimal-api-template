namespace MinimalApiTemplate.Api.ApiEndpoints;

public static class ApiTestEndpoints
{
    public static void UseApiTestEndpoints(this WebApplication app)
    {
        app.MapGet("/test", () => "Hello World!")
            .WithTags("Test")
            .WithOpenApi(openApiOperation =>
            {
                openApiOperation.Summary = "Home api call";
                openApiOperation.Description = "Displays hello world";
                return openApiOperation;
            })
            .AllowAnonymous();
    }
}