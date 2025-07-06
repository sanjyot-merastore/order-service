# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/MeraStore.Services.Order.Api/MeraStore.Services.Order.Api.csproj", "src/MeraStore.Services.Order.Api/"]
COPY ["src/MeraStore.Services.Order.Infrastructure/MeraStore.Services.Order.Infrastructure.csproj", "src/MeraStore.Services.Order.Infrastructure/"]
COPY ["src/MeraStore.Services.Order.Persistence/MeraStore.Services.Order.Persistence.csproj", "src/MeraStore.Services.Order.Persistence/"]
COPY ["src/MeraStore.Services.Order.Application/MeraStore.Services.Order.Application.csproj", "src/MeraStore.Services.Order.Application/"]
COPY ["src/MeraStore.Services.Order.Domain/MeraStore.Services.Order.Domain.csproj", "src/MeraStore.Services.Order.Domain/"]
COPY ["src/MeraStore.Services.Order.Common/MeraStore.Services.Order.Common.csproj", "src/MeraStore.Services.Order.Common/"]
RUN dotnet restore "./src/MeraStore.Services.Order.Api/MeraStore.Services.Order.Api.csproj"
COPY . .
WORKDIR "/src/src/MeraStore.Services.Order.Api"
RUN dotnet build "./MeraStore.Services.Order.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./MeraStore.Services.Order.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MeraStore.Services.Order.Api.dll"]