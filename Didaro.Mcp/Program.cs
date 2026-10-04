using Didaro.Mcp.Extensions;
using ModelContextProtocol.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuth0Authentication(
    builder.Configuration);

builder.Services.AddApplicationServices(
    builder.Configuration);

builder.Services.AddAuthorization();

builder.Services
    .AddMcpServer()
    .WithHttpTransport(options =>
    {
        options.SessionMode = HttpServerSessionMode.Stateless;
    })
    .WithToolsFromAssembly();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.MapMcp("/mcp")
    .RequireAuthorization();

app.Run();