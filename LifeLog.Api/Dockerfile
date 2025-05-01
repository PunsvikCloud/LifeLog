FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["LifeLog.Api/LifeLog.Api.csproj", "LifeLog.Api/"]
COPY ["LifeLog.ServiceDefaults/LifeLog.ServiceDefaults.csproj", "LifeLog.ServiceDefaults/"]
RUN dotnet restore "LifeLog.Api/LifeLog.Api.csproj"
COPY . .
WORKDIR "/src/LifeLog.Api"
RUN dotnet build "./LifeLog.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./LifeLog.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LifeLog.Api.dll"]
