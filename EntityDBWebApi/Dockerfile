#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["EntityDBWebApi/EntityDBWebApi.csproj", "EntityDBWebApi/"]
COPY ["LMS.Data/LMS.Data.csproj", "LMS.Data/"]
COPY ["LMS.Service/LMS.Services.csproj", "LMS.Service/"]
RUN dotnet restore "./EntityDBWebApi/EntityDBWebApi.csproj"
COPY . .
WORKDIR "/src/EntityDBWebApi"
RUN dotnet build "./EntityDBWebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./EntityDBWebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EntityDBWebApi.dll"]