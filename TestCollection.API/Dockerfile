FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["TestCollection.API/TestCollection.API.csproj", "TestCollection.API/"]
RUN dotnet restore "TestCollection.API/TestCollection.API.csproj"
COPY . .
WORKDIR "/src/TestCollection.API"
RUN dotnet build "TestCollection.API.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "TestCollection.API.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "TestCollection.API.dll"]