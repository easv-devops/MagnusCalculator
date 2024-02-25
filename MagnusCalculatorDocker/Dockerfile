FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["MagnusCalculatorDocker/MagnusCalculatorDocker.csproj", "MagnusCalculatorDocker/"]
RUN dotnet restore "MagnusCalculatorDocker/MagnusCalculatorDocker.csproj"
COPY . .
WORKDIR "/src/MagnusCalculatorDocker"
RUN dotnet build "MagnusCalculatorDocker.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MagnusCalculatorDocker.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MagnusCalculatorDocker.dll"]
