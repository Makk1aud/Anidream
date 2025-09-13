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
COPY ["Anidream.Api.Application.Core/Anidream.Api.Application.Core.csproj", "Anidream.Api.Application.Core/"]
COPY ["Anidream.Api.Application/Anidream.Api.Application.csproj", "Anidream.Api.Application/"]
COPY ["Anidream.Api.Application.UseCases/Anidream.Api.Application.UseCases.csproj", "Anidream.Api.Application.UseCases/"]
COPY ["Anidream.Api.Application.Shared/Anidream.Api.Application.Shared.csproj", "Anidream.Api.Application.Shared/"]
COPY ["Anidream.Api.Domain/Anidream.Api.Domain.csproj", "Anidream.Api.Domain/"]
COPY ["Anidream.Api.DataAccess/Anidream.Api.DataAccess.csproj", "Anidream.Api.DataAccess/"]
COPY ["Anidream.Api.Infrastructure.Utils/Anidream.Api.Infrastructure.Utils.csproj", "Anidream.Api.Infrastructure.Utils/"]
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
