using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Host.Extensions;
using Microsoft.EntityFrameworkCore;
using Modules.Messages;
using Modules.Messages.Infrastructure.Persistence;
using Modules.Servers;
using Modules.Servers.Infrastructure.Persistence;
using Serilog;
using Shared.Infrastructure.MediatorConfiguration;
using Shared.Infrastructure.Transformers;
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
builder.Services.AddServersModule(builder.Configuration);
builder.Services.AddMessagesModule(builder.Configuration);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Host.UseSerilog((context, configuration) =>
{
    configuration.ReadFrom.Configuration(context.Configuration);
});

builder.Services.AddMediator(options =>
{
    options.Assemblies.Add(Assembly.Load("Modules.Servers"));
    options.Assemblies.Add(Assembly.Load("Modules.Messages"));
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

app.UseHttpsRedirection();

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