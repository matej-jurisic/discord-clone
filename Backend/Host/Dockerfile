FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

COPY Backend.sln ./
COPY Host/Host.csproj Host/
COPY Infrastructure/Infrastructure.csproj Infrastructure/
COPY Kernel/Kernel.csproj Kernel/

# Messages Module
COPY Modules.Messages.Endpoints/Modules.Messages.Endpoints.csproj Modules.Messages.Endpoints/
COPY Modules.Messages.Application/Modules.Messages.Application.csproj Modules.Messages.Application/
COPY Modules.Messages.Domain/Modules.Messages.Domain.csproj Modules.Messages.Domain/
COPY Modules.Messages.Infrastructure/Modules.Messages.Infrastructure.csproj Modules.Messages.Infrastructure/
COPY Modules.Messages.IntegrationEvents/Modules.Messages.IntegrationEvents.csproj Modules.Messages.IntegrationEvents/

# Servers Module
COPY Modules.Servers.Endpoints/Modules.Servers.Endpoints.csproj Modules.Servers.Endpoints/
COPY Modules.Servers.Application/Modules.Servers.Application.csproj Modules.Servers.Application/
COPY Modules.Servers.Domain/Modules.Servers.Domain.csproj Modules.Servers.Domain/
COPY Modules.Servers.Infrastructure/Modules.Servers.Infrastructure.csproj Modules.Servers.Infrastructure/
COPY Modules.Servers.IntegrationEvents/Modules.Servers.IntegrationEvents.csproj Modules.Servers.IntegrationEvents/

RUN dotnet restore Backend.sln

COPY . .
RUN dotnet publish Host/Host.csproj -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 8080
ENTRYPOINT ["dotnet", "Host.dll"]