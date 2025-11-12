FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Directory.Packages.props", ""]
COPY ["Anidream.Api/Anidream.Api.csproj", "Anidream.Api/"]
COPY ["Anidream.Application/Anidream.Application.csproj", "Anidream.Application/"]
COPY ["Anidream.Application.Contracts/Anidream.Application.Contracts.csproj", "Anidream.Application.Contracts/"]
COPY ["Anidream.Application.Interfaces/Anidream.Application.Interfaces.csproj", "Anidream.Application.Interfaces/"]
COPY ["Anidream.Application.UseCases/Anidream.Application.UseCases.csproj", "Anidream.Application.UseCases/"]
COPY ["Anidream.DataAccess/Anidream.DataAccess.csproj", "Anidream.DataAccess/"]
COPY ["Anidream.DataAccess.Implementation/Anidream.DataAccess.Implementation.csproj", "Anidream.DataAccess.Implementation/"]
COPY ["Anidream.Domain/Anidream.Domain.csproj", "Anidream.Domain/"]
COPY ["Anidream.Infrastructure/Anidream.Infrastructure.csproj", "Anidream.Infrastructure/"]
RUN dotnet restore "Anidream.Api/Anidream.Api.csproj"
COPY . .
WORKDIR "/src/Anidream.Api"
RUN dotnet build "./Anidream.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Anidream.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Anidream.Api.dll", "--environment=Production"]
