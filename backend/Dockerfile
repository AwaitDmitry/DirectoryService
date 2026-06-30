FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/DirectoryService.Web/DirectoryService.Web.csproj", "src/DirectoryService.Web/"]
COPY ["src/DirectoryService.Contracts/DirectoryService.Contracts.csproj", "src/DirectoryService.Contracts/"]
COPY ["src/DirectoryService.Domain/DirectoryService.Domain.csproj", "src/DirectoryService.Domain/"]
COPY ["src/DirectoryService.Core/DirectoryService.Core.csproj", "src/DirectoryService.Core/"]
COPY ["Directory.Build.props", "Directory.Build.props"]
COPY ["Directory.Package.props", "Directory.Package.props"]

RUN dotnet restore "src/DirectoryService.Web/DirectoryService.Web.csproj"
COPY . .
WORKDIR "/src/src/DirectoryService.Web"
RUN dotnet build "./DirectoryService.Web.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./DirectoryService.Web.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DirectoryService.Web.dll"]
