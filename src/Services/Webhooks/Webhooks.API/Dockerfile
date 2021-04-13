#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["Services/Webhooks/Webhooks.API/Webhooks.API.csproj", "Services/Webhooks/Webhooks.API/"]
COPY ["Services/Webhooks/Webhooks.Infrastructure/Webhooks.Infrastructure.csproj", "Services/Webhooks/Webhooks.Infrastructure/"]
COPY ["Services/Webhooks/Webhooks.Domain/Webhooks.Domain.csproj", "Services/Webhooks/Webhooks.Domain/"]
RUN dotnet restore "Services/Webhooks/Webhooks.API/Webhooks.API.csproj"
COPY . .
WORKDIR "/src/Services/Webhooks/Webhooks.API"
RUN dotnet build "Webhooks.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Webhooks.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Webhooks.API.dll"]
