using Didaro.Mcp.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using ModelContextProtocol.AspNetCore.Authentication;

namespace Didaro.Mcp.Extensions;

public static class AuthenticationServiceCollectionExtensions
{
    /// <summary>
    /// Adds Auth0 authentication to the service collection.
    /// </summary>
    /// <param name="services">The service collection to add authentication to.</param>
    /// <param name="configuration">The application configuration containing Auth0 settings.</param>
    /// <returns>The updated service collection.</returns>
    /// <exception cref="InvalidOperationException"></exception>
    public static IServiceCollection AddAuth0Authentication(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        Auth0Options auth0 = configuration
            .GetSection(Auth0Options.SectionName)
            .Get<Auth0Options>()
            ?? throw new InvalidOperationException(
                "Auth0 configuration is missing.");

        string authority =
            $"https://{auth0.Domain.TrimEnd('/')}/";

        services
            .AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme =
                    JwtBearerDefaults.AuthenticationScheme;

                options.DefaultChallengeScheme =
                    McpAuthenticationDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.Authority = authority;
                options.Audience = auth0.Audience;
                options.MapInboundClaims = false;
            })
            .AddMcp(options =>
            {
                options.ResourceMetadata = new()
                {
                    Resource = auth0.Audience,
                    AuthorizationServers =
                    {
                        authority
                    }
                };
            });

        return services;
    }
}