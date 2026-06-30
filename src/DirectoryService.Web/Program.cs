using DirectoryService.Web.Configuration;
using DirectoryService.Web.EndpointsSettings;
using Microsoft.OpenApi;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddConfiguration(builder.Configuration);

WebApplication app = builder.Build();

app.Configure();

app.Run();