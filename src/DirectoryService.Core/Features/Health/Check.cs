using DirectoryService.Core.EndpointsSettings;
using Microsoft.AspNetCore.Mvc;

namespace DirectoryService.Core.Features.Health;

public sealed class CheckEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/health", async ([FromServices] CheckHandler handler) =>
        {
            return await handler.Handle();
        });
    }
}

public sealed class CheckHandler
{
    public async Task<IResult> Handle()
    {
        await Task.Delay(TimeSpan.FromSeconds(1));
        return Results.Ok();
    }
}