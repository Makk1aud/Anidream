FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Directory.Packages.props", ""]
COPY ["Anidream.API/Anidream.API.csproj", "Anidream.API/"]
COPY ["Domain/Domain.csproj", "Domain/"]
COPY ["DataAccess.Interfaces/DataAccess.Interfaces.csproj", "DataAccess.Interfaces/"]
COPY ["DataAccess/DataAccess.csproj", "DataAccess/"]
RUN dotnet restore "Anidream.API/Anidream.API.csproj"
COPY . .
WORKDIR "/src/Anidream.API"
RUN dotnet build "./Anidream.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Anidream.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Anidream.API.dll", "--environment=Production"]
