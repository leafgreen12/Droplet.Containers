#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Services/Settings/Settings.API/Settings.API.csproj", "Services/Settings/Settings.API/"]
COPY ["BuildingBlocks/WebHost.Customization/WebHost.Customization.csproj", "BuildingBlocks/WebHost.Customization/"]
COPY ["BuildingBlocks/EventBus/IntegrationEventLogEF/IntegrationEventLogEF.csproj", "BuildingBlocks/EventBus/IntegrationEventLogEF/"]
COPY ["BuildingBlocks/EventBus/EventBus/EventBus.csproj", "BuildingBlocks/EventBus/EventBus/"]
COPY ["BuildingBlocks/EventBus/EventBusRabbitMQ/EventBusRabbitMQ.csproj", "BuildingBlocks/EventBus/EventBusRabbitMQ/"]
COPY ["Services/Settings/Settings.Domain/Settings.Domain.csproj", "Services/Settings/Settings.Domain/"]
COPY ["Services/Settings/Settings.Infrastructure/Settings.Infrastructure.csproj", "Services/Settings/Settings.Infrastructure/"]
COPY ["BuildingBlocks/EventBus/EventBusServiceBus/EventBusServiceBus.csproj", "BuildingBlocks/EventBus/EventBusServiceBus/"]
RUN dotnet restore "Services/Settings/Settings.API/Settings.API.csproj"
COPY . .
WORKDIR "/src/Services/Settings/Settings.API"
RUN dotnet build "Settings.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Settings.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Settings.API.dll"]
