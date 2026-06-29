using Microsoft.OpenApi;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Services.AddSwaggerGen(options =>
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

WebApplication app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/test", () => "Hello World!");

app.Run();