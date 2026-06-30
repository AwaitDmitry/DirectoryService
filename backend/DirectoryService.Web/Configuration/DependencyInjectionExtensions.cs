using DirectoryService.Core;
using DirectoryService.Core.Features.Health;
using DirectoryService.Web.EndpointsSettings;
using Microsoft.OpenApi;
using Serilog;
using Serilog.Exceptions;

namespace DirectoryService.Web.Configuration;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        return services
            .AddSerilogLogging(configuration)
            .AddEndpoints(typeof(IEndpoint).Assembly)
            .AddOpenApiSpec()
            .AddScoped<CheckHandler>();
    }

    private static IServiceCollection AddOpenApiSpec(this IServiceCollection services)
    {
        services.AddOpenApi();

        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Directory Service",
                Version = "v1",
                Contact = new OpenApiContact
                {
                    Name = "AwaitDmitry",
                }
            });
        });

        return services;
    }

    private static IServiceCollection AddSerilogLogging(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSerilog((sp, lc) => lc
            .ReadFrom.Configuration(configuration)
            .ReadFrom.Services(sp)
            .Enrich.FromLogContext()
            .Enrich.WithExceptionDetails()
            .Enrich.WithProperty("ServiceName", "DirectoryService"));

        return services;
    }
}