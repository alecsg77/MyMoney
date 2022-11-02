#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["NuGet.Config", "."]
COPY ["src/AlecsG77.MyMoney.DbMigrator/AlecsG77.MyMoney.DbMigrator.csproj", "src/AlecsG77.MyMoney.DbMigrator/"]
COPY ["src/AlecsG77.MyMoney.Application.Contracts/AlecsG77.MyMoney.Application.Contracts.csproj", "src/AlecsG77.MyMoney.Application.Contracts/"]
COPY ["src/AlecsG77.MyMoney.Domain.Shared/AlecsG77.MyMoney.Domain.Shared.csproj", "src/AlecsG77.MyMoney.Domain.Shared/"]
COPY ["src/AlecsG77.MyMoney.EntityFrameworkCore/AlecsG77.MyMoney.EntityFrameworkCore.csproj", "src/AlecsG77.MyMoney.EntityFrameworkCore/"]
COPY ["src/AlecsG77.MyMoney.Domain/AlecsG77.MyMoney.Domain.csproj", "src/AlecsG77.MyMoney.Domain/"]
RUN dotnet restore "src/AlecsG77.MyMoney.DbMigrator/AlecsG77.MyMoney.DbMigrator.csproj"
COPY . .
WORKDIR "/src/src/AlecsG77.MyMoney.DbMigrator"
RUN dotnet build "AlecsG77.MyMoney.DbMigrator.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AlecsG77.MyMoney.DbMigrator.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AlecsG77.MyMoney.DbMigrator.dll"]