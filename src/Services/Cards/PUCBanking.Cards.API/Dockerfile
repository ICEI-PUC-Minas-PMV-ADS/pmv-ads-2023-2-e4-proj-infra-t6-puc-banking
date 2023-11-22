#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Services/Cards/PUCBanking.Cards.API/PUCBanking.Cards.API.csproj", "Services/Cards/PUCBanking.Cards.API/"]
RUN dotnet restore "Services/Cards/PUCBanking.Cards.API/PUCBanking.Cards.API.csproj"
COPY . .
WORKDIR "/src/Services/Cards/PUCBanking.Cards.API"
RUN dotnet build "PUCBanking.Cards.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PUCBanking.Cards.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PUCBanking.Cards.API.dll"]