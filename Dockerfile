# Runtime base image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Build and publish app
FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS publish
WORKDIR /src
COPY . .
RUN dotnet publish -c Release -o /app/publish

# Final stage
FROM base AS final
WORKDIR /app

# Accept ENV argument from build system (like Cloud Build)
ARG ENVIRONMENT=Development
ENV ENVIRONMENT=${ENVIRONMENT}

COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "Artportable.API.dll"]
