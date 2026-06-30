using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;

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
    private readonly ILogger<CheckHandler> _logger;

    public CheckHandler(ILogger<CheckHandler> logger)
    {
        _logger = logger;
    }

    public Task<IResult> Handle()
    {
        _logger.LogDebug("Health checked");
        return Task.FromResult(Results.Ok());
    }
}