#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["TwoWebTwoDbTwoNetworks_Web_2/TwoWebTwoDbTwoNetworks_Web_2.csproj", "TwoWebTwoDbTwoNetworks_Web_2/"]
COPY ["DataAccess/DataAccess.csproj", "DataAccess/"]
COPY ["Models/Models.csproj", "Models/"]
RUN dotnet restore "TwoWebTwoDbTwoNetworks_Web_2/TwoWebTwoDbTwoNetworks_Web_2.csproj"
COPY . .
WORKDIR "/src/TwoWebTwoDbTwoNetworks_Web_2"
RUN dotnet build "TwoWebTwoDbTwoNetworks_Web_2.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TwoWebTwoDbTwoNetworks_Web_2.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TwoWebTwoDbTwoNetworks_Web_2.dll"]