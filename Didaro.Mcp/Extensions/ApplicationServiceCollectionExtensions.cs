using Didaro.Mcp.Configuration;
using Didaro.Mcp.Interfaces;
using Didaro.Mcp.Services;

namespace Didaro.Mcp.Extensions;

public static class ApplicationServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.Configure<DidaroApiOptions>(
            configuration.GetSection(
                DidaroApiOptions.SectionName));

        services.Configure<Auth0Options>(
            configuration.GetSection(
                Auth0Options.SectionName));

        services.AddHttpClient();

        services.AddScoped<
            ITokenExchangeService,
            TokenExchangeService>();

        services.AddHttpContextAccessor();

        services.AddScoped<
            IAccessTokenService,
            AccessTokenService>();

        services.AddScoped<
            ITokenExchangeService,
            TokenExchangeService>();

        services.AddScoped<
            IDidaroApiClient,
            DidaroApiClient>();

        return services;
    }
}