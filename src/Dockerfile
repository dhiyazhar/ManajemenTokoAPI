FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

RUN apt-get update && apt-get install -y postgresql-client && rm -rf /var/lib/apt/lists/*

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src.csproj", "./"]
RUN dotnet restore "src.csproj"
COPY . .
RUN dotnet build "/src/src.csproj" -c $BUILD_CONFIGURATION -o /app/build
RUN dotnet --version
RUN dotnet tool install --global dotnet-ef --version 9.0 && \
    /root/.dotnet/tools/dotnet-ef --version 
ENV PATH="${PATH}:/root/.dotnet/tools"
RUN dotnet-ef --version

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "/src/src.csproj" -c $BUILD_CONFIGURATION -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "src.dll"]

# COPY ["entrypoint.sh", "./"]
# RUN chmod +x /app/entrypoint.sh
# ENTRYPOINT ["/app/entrypoint.sh"]