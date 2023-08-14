FROM mcr.microsoft.com/dotnet/sdk:7.0.400 AS build
WORKDIR /src

# Restore nuget packages in order to allow them being cached
# for upcoming steps
COPY ["BattleBitGraphQLApi.csproj", "./"]
RUN dotnet restore "BattleBitGraphQLApi.csproj"

# Copy rest of the files needed for building backend
COPY [".", "./"]
RUN dotnet build "BattleBitGraphQLApi.csproj" -c Release -o /app

FROM build AS publish

RUN dotnet publish \
    -r linux-x64 \
    -p:PublishTrimmed=true \
    -p:PublishSingleFile=true \
    -p:PublishReadyToRun=true \
    --self-contained "BattleBitGraphQLApi.csproj" \
    -c Release \
    -o /app

FROM mcr.microsoft.com/dotnet/runtime:7.0.10 AS final
WORKDIR /app

COPY --from=publish /app .

EXPOSE 80
EXPOSE 443

ENTRYPOINT [ "/app/BattleBitGraphQLApi" ]