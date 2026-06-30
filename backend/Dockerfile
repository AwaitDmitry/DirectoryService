FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["DirectoryService.Web/DirectoryService.Web.csproj", "DirectoryService.Web/"]
COPY ["DirectoryService.Contracts/DirectoryService.Contracts.csproj", "DirectoryService.Contracts/"]
COPY ["DirectoryService.Domain/DirectoryService.Domain.csproj", "DirectoryService.Domain/"]
COPY ["DirectoryService.Core/DirectoryService.Core.csproj", "DirectoryService.Core/"]
COPY ["Directory.Build.props", "Directory.Build.props"]
COPY ["Directory.Package.props", "Directory.Package.props"]

RUN dotnet restore "DirectoryService.Web/DirectoryService.Web.csproj"
COPY . .
WORKDIR "/DirectoryService.Web"
RUN dotnet build "./DirectoryService.Web.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./DirectoryService.Web.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DirectoryService.Web.dll"]
