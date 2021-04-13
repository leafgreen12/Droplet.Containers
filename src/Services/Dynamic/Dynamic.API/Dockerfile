#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Services/Dynamic/Dynamic.API/Dynamic.API.csproj", "Services/Dynamic/Dynamic.API/"]
COPY ["Services/Dynamic/Dynamic.Infrastructure/Dynamic.Infrastructure.csproj", "Services/Dynamic/Dynamic.Infrastructure/"]
COPY ["Services/Dynamic/Dynamic.Domain/Dynamic.Domain.csproj", "Services/Dynamic/Dynamic.Domain/"]
RUN dotnet restore "Services/Dynamic/Dynamic.API/Dynamic.API.csproj"
COPY . .
WORKDIR "/src/Services/Dynamic/Dynamic.API"
RUN dotnet build "Dynamic.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Dynamic.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Dynamic.API.dll"]
