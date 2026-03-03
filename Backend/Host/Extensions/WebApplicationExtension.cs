using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using System.Text.Json;

namespace Host.Extensions;

public static class WebApplicationExtension
{
    public static WebApplication MapHealthCheckEndpoint(this WebApplication app)
    {
        app.MapHealthChecks("/health", new HealthCheckOptions
        {
            Predicate = _ => true,
            ResponseWriter = async (context, report) =>
            {
                var response = new
                {
                    status = report.Status.ToString(),
                    duration = report.TotalDuration.TotalMilliseconds,
                    checks = report.Entries.Select(x => new
                    {
                        name = x.Key,
                        status = x.Value.Status.ToString(),
                        description = x.Value.Description,
                        duration = x.Value.Duration.TotalMilliseconds,
                        tags = x.Value.Tags,
                        error = x.Value.Exception?.Message
                    })
                };

                await context.Response.WriteAsync(JsonSerializer.Serialize(response, new JsonSerializerOptions
                {
                    WriteIndented = true
                }));
            }
        });

        return app;
    }
}