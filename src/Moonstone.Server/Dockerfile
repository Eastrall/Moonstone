#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:5.0-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["src/Moonstone.Server/Moonstone.Server.csproj", "src/Moonstone.Server/"]
COPY ["src/Moonstone.Configuration.Yaml/Moonstone.Configuration.Yaml.csproj", "src/Moonstone.Configuration.Yaml/"]
COPY ["src/Moonstone.Protocol/Moonstone.Protocol.csproj", "src/Moonstone.Protocol/"]
COPY ["src/Moonstone.Common/Moonstone.Common.csproj", "src/Moonstone.Common/"]
RUN dotnet restore "src/Moonstone.Server/Moonstone.Server.csproj"
COPY . .
WORKDIR "/src/src/Moonstone.Server"
RUN dotnet build "Moonstone.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Moonstone.Server.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Moonstone.Server.dll"]