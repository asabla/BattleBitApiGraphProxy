FROM mcr.microsoft.com/dotnet/sdk:8.0 AS restore
WORKDIR /src

# Restore nuget packages in order to allow them being cached
# for upcoming steps
COPY ["BattleBitGraphQLApi.csproj", "./"]
RUN dotnet restore "BattleBitGraphQLApi.csproj"

FROM restore AS build
WORKDIR /src

COPY --from=restore /src .

# Copy rest of the files needed for building backend
COPY . .

RUN dotnet build "BattleBitGraphQLApi.csproj" -c Release -o /app

FROM build AS publish
WORKDIR /src

COPY --from=build /src .

RUN dotnet publish \
    -r linux-x64 \
    # -p:PublishTrimmed=true \
    -p:PublishSingleFile=true \
    -p:PublishReadyToRun=true \
    --self-contained "BattleBitGraphQLApi.csproj" \
    -c Release \
    -o /app

FROM mcr.microsoft.com/dotnet/runtime:8.0 AS final
WORKDIR /app

COPY --from=publish /app .

EXPOSE 80
EXPOSE 443

ENTRYPOINT [ "/app/BattleBitGraphQLApi" ]
