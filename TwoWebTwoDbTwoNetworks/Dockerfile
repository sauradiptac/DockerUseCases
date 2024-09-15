#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["TwoWebTwoDbTwoNetworks/TwoWebTwoDbTwoNetworks.csproj", "TwoWebTwoDbTwoNetworks/"]
COPY ["DataAccess/DataAccess.csproj", "DataAccess/"]
COPY ["Models/Models.csproj", "Models/"]
RUN dotnet restore "TwoWebTwoDbTwoNetworks/TwoWebTwoDbTwoNetworks.csproj"
COPY . .
WORKDIR "/src/TwoWebTwoDbTwoNetworks"
RUN dotnet build "TwoWebTwoDbTwoNetworks.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TwoWebTwoDbTwoNetworks.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TwoWebTwoDbTwoNetworks.dll"]