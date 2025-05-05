# Runtime base
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Build + publish
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY . .
RUN dotnet publish -c Release -o /app/publish

# Final image
FROM base AS final
WORKDIR /app
ARG ENVIRONMENT=Development
ENV ENVIRONMENT=$ENVIRONMENT
ENV ASPNETCORE_ENVIRONMENT=$ENVIRONMENT
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Artportable.API.dll"]
