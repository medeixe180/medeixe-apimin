FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["MedeixeApi.csproj", "./"]
RUN dotnet restore "MedeixeApi.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "MedeixeApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MedeixeApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
ARG DB_PASSWORD
ENV DB_PASSWORD=$DB_PASSWORD
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MedeixeApi.dll"]