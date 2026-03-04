using Infrastructure.MediatorConfiguration;
using Infrastructure.Transformers;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Host.Extensions;
using Microsoft.EntityFrameworkCore;
using Modules.Messages.Endpoints;
using Modules.Messages.Infrastructure;
using Modules.Messages.Infrastructure.Persistence;
using Modules.Servers.Endpoints;
using Modules.Servers.Infrastructure;
using Modules.Servers.Infrastructure.Persistence;
using Serilog;
using System.Reflection;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOpenApi();

builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddControllers(options =>
{
    options.Conventions.Add(
        new RouteTokenTransformerConvention(new ControllerNameTransformer())
    );
});

builder.Services.AddServersEndpoints();
builder.Services.AddServersInfrastructure(builder.Configuration);

builder.Services.AddMessagesEndpoints();
builder.Services.AddMessagesInfrastructure(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Host.UseSerilog((context, configuration) =>
{
    configuration.ReadFrom.Configuration(context.Configuration);
});

builder.Services.AddMediator(options =>
{
    options.Assemblies.Add(Assembly.Load("Modules.Servers.Application"));
    options.Assemblies.Add(Assembly.Load("Modules.Messages.Application"));
});

builder.Services.AddHealthCheckEndpoint(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSerilogRequestLogging();

if (!app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}

app.UseAuthorization();

app.MapControllers();
app.MapHealthCheckEndpoint();

using (var scope = app.Services.CreateScope())
{
    var serversDb = scope.ServiceProvider.GetRequiredService<ServersDbContext>();
    serversDb.Database.Migrate();

    var messagesDb = scope.ServiceProvider.GetRequiredService<MessagesDbContext>();
    messagesDb.Database.Migrate();
}

app.Run();
