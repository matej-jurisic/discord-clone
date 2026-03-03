using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Host.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddHealthCheckEndpoint(this IServiceCollection services, IConfiguration configuration)
    {
        var postgresCS = configuration.GetValue<string>("ConnectionStrings:Postgres");
        var redisCS = configuration.GetValue<string>("ConnectionStrings:Redis");

        if (postgresCS is null) 
            throw new InvalidOperationException("Postgres connection string is not defined");

        if (redisCS is null)
            throw new InvalidOperationException("Redis connection string is not defined");

        services.AddHealthChecks()
            .AddNpgSql(
                postgresCS, 
                healthQuery: "select 1", 
                name: "postgres", 
                failureStatus: HealthStatus.Unhealthy, 
                tags: new[] { "Database" }
            );

        return services;
    }
}
