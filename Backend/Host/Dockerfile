FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

COPY Backend.sln ./
COPY Host/Host.csproj Host/
COPY Shared.Infrastructure/Shared.Infrastructure.csproj Shared.Infrastructure/
COPY Shared.Kernel/Shared.Kernel.csproj Shared.Kernel/
COPY Modules.Servers/Modules.Servers.csproj Modules.Servers/

RUN dotnet restore

COPY . .
RUN dotnet publish Host/Host.csproj -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 8080
ENTRYPOINT ["dotnet", "Host.dll"]