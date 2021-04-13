#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Services/Storage/Storage.API/Storage.API.csproj", "Services/Storage/Storage.API/"]
COPY ["Services/Storage/Storage.Infrastructure/Storage.Infrastructure.csproj", "Services/Storage/Storage.Infrastructure/"]
COPY ["Services/Storage/Storage.Domain/Storage.Domain.csproj", "Services/Storage/Storage.Domain/"]
RUN dotnet restore "Services/Storage/Storage.API/Storage.API.csproj"
COPY . .
WORKDIR "/src/Services/Storage/Storage.API"
RUN dotnet build "Storage.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Storage.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Storage.API.dll"]
