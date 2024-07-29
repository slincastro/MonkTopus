# Use the official Microsoft .NET 8 SDK image to build the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app
EXPOSE 8080
# Copy csproj files and restore any dependencies (via NuGet)
COPY Transactional/Presentation/Presentation.csproj Transactional/Presentation/
COPY Transactional/Application/Application.csproj Transactional/Application/
COPY Transactional/Domain/Domain.csproj Transactional/Domain/
COPY Transactional/Infrastructure/Infrastructure.csproj Transactional/Infrastructure/

# Restore the packages
RUN dotnet restore Transactional/Presentation/Presentation.csproj

# Copy the rest of the source code
COPY . .

# Set the working directory and publish the application
WORKDIR /app/Transactional/Presentation
RUN dotnet publish -c Release -o out

# Build the runtime image using the .NET 8 ASP.NET runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/Transactional/Presentation/out .
ENTRYPOINT ["dotnet", "Presentation.dll"]
HEALTHCHECK --interval=30s --timeout=30s --start-period=5s --retries=3 \
  CMD curl -f http://localhost:8080/health || exit 1

