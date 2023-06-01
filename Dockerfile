# Build stage
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

# Copy csproj files and restore dependencies
COPY . .
RUN dotnet restore

# Publish the projects
RUN dotnet publish -c Release -o /app/publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

# Run the application
ENTRYPOINT ["dotnet", "WebUI.dll"]
