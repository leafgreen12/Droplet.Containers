#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/Services/Emailing/Emailing.API/Emailing.API.csproj", "src/Services/Emailing/Emailing.API/"]
RUN dotnet restore "src/Services/Emailing/Emailing.API/Emailing.API.csproj"
COPY . .
WORKDIR "/src/src/Services/Emailing/Emailing.API"
RUN dotnet build "Emailing.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Emailing.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Emailing.API.dll"]
