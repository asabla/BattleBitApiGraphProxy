using System.Text.Json;

using BattleBitProxy.Backend.BattleBitGraphQLApi.Extensions;
using BattleBitProxy.Backend.BattleBitGraphQLApi.Models.BattleBitAPIModels;
using BattleBitProxy.Backend.BattleBitGraphQLApi.Models.GraphQLModels;
using BattleBitProxy.Backend.BattleBitGraphQLApi.Models.GraphQLModels.Types;
using BattleBitProxy.Backend.BattleBitGraphQLApi.Types;

using Microsoft.Extensions.Caching.Memory;

namespace BattleBitProxy.Backend.BattleBitGraphQLApi.Services;

public class BattleBitAPIService
{
    private readonly ILogger<BattleBitAPIService> _logger;
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IMemoryCache _memoryCache;

    public BattleBitAPIService(
        ILogger<BattleBitAPIService> logger,
        IHttpClientFactory httpClientFactory,
        IMemoryCache memoryCache)
    {
        _logger = logger;
        _httpClientFactory = httpClientFactory;
        _memoryCache = memoryCache;
    }

    public async Task<IReadOnlyList<ServerInfo>> GetAllServersAsync(
        CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Fetching server BattleBit servers");

        var result = null as IReadOnlyList<BattleBitAPIServerInfo>;

        result = await _memoryCache.GetOrCreateAsync(
            key: nameof(BattleBitAPIServerInfo),
            factory: async cacheEntry =>
            {
                cacheEntry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(2);

                var httpClient = _httpClientFactory.CreateClient(HttpClientName.BattleBitAPI);

                return await httpClient.GetFromJsonAsync<IReadOnlyList<BattleBitAPIServerInfo>>(
                        requestUri: "Servers/GetServerList",
                        options: new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true
                        },
                        cancellationToken: cancellationToken)
                    ?? null!;
            });

        return result?.Select(x => new ServerInfo
        {
            AntiCheat = x.AntiCheat.CastTo(AntiCheatType.None),
            Build = x.Build,
            DayNight = x.DayNight.CastTo(DayNightType.None),
            GameMode = x.Gamemode.CastTo(GameModeType.None),
            HasPassword = x.HasPassword,
            Hz = x.Hz,
            IsOfficial = x.IsOfficial,
            Map = x.Map.CastTo(MapType.None),
            MapSize = x.MapSize.CastTo(MapSizeType.None),
            MaxPlayers = x.MaxPlayers,
            Name = x.Name,
            Players = x.Players,
            QueuePlayers = x.QueuePlayers,
            Region = x.Region.CastTo(RegionType.None)
        }).ToList() ?? null!;
    }
}