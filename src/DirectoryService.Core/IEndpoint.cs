using Microsoft.AspNetCore.Routing;

namespace DirectoryService.Core;

public interface IEndpoint
{
    void MapEndpoint(IEndpointRouteBuilder app);
}