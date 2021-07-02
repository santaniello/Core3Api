# Setup base image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Build
FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Core3Api.csproj", "."]
RUN dotnet restore "Core3Api.csproj"
COPY . .
WORKDIR "/src"
RUN dotnet build "Core3Api.csproj" -c Release -o /app/build

# ## Install dotnet-trace, dotnet-counters, and dotnet-dump
RUN dotnet tool install --tool-path /tools dotnet-trace
RUN dotnet tool install --tool-path /tools dotnet-counters
RUN dotnet tool install --tool-path /tools dotnet-dump
RUN dotnet tool install --tool-path /tools dotnet-gcdump

# Publish
FROM build AS publish
RUN dotnet publish "Core3Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /tools
COPY --from=publish /tools .

WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Core3Api.dll"]