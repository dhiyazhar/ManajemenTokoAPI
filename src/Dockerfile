FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

RUN dotnet tool install --global dotnet-ef
ENV PATH $PATH:/root/.dotnet/tools

FROM base AS development
WORKDIR /src
COPY ["ManajemenToko.sln", "./"]
COPY ["src/src.csproj", "src/"]
RUN dotnet restore "ManajemenToko.sln"
COPY . .

RUN chmod +x /app/entrypoint.sh
ENTRYPOINT ["/app/entrypoint.sh"]