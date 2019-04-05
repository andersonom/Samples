FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["HeathChecks/HeathChecks.csproj", "HeathChecks/"]
RUN dotnet restore "HeathChecks/HeathChecks.csproj"
COPY . .
WORKDIR "/src/HeathChecks"
RUN dotnet build "HeathChecks.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "HeathChecks.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "HeathChecks.dll"]