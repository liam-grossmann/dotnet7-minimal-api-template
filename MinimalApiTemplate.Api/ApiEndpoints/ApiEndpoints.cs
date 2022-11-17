namespace MinimalApiTemplate.Api.ApiEndpoints;

public static class ApiEndpoints
{
    public static void UseApiEndpoints(this WebApplication app)
    {
        // Map redirect to Swagger
        if (app.Environment.IsDevelopment())
        {
            app.MapGet("/", () => Results.Redirect("swagger"))
                .ExcludeFromDescription();
        }
        
        app.UseApiTestEndpoints();
        app.UseApiUserEndpoints();
    }
}