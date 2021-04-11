#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/Web/Web.Status/Web.Status.csproj", "src/Web/Web.Status/"]
RUN dotnet restore "src/Web/Web.Status/Web.Status.csproj"
COPY . .
WORKDIR "/src/src/Web/Web.Status"
RUN dotnet build "Web.Status.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Web.Status.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Web.Status.dll"]
