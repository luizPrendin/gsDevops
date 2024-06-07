# Use the official .NET SDK image to build the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Build variables
ARG BUILD_CONFIGURATION=Release
ENV ASPNETCORE_ENVIRONMENT=Development

# Copy the .csproj file and restore dependencies
COPY GS.csproj ./GS/
RUN dotnet restore ./GS/GS.csproj

# Copy the rest of the application code and build the release
COPY . ./GS/
WORKDIR /app/GS

# Ensure all packages are restored before publish
RUN dotnet restore

# Use project file directly to avoid solution-level output issues
RUN dotnet publish GS.csproj -c $BUILD_CONFIGURATION -o /app/out

# Use the official ASP.NET Core runtime image optimized for production
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Add a non-root user
RUN adduser --disabled-password --gecos '' appuser && chown -R appuser /app
USER appuser

# Copy the application binaries from the build stage
COPY --from=build /app/out .

# Persist data in a volume (optional)
VOLUME ["/app/data"]

ENTRYPOINT ["dotnet", "GS.dll"]
