using DirectoryService.Core.Configuration;
using DirectoryService.Core.EndpointsSettings;
using DirectoryService.Core.Features.Health;
using Microsoft.OpenApi;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddConfiguration(builder.Configuration);

WebApplication app = builder.Build();

app.Configure();

app.Run();