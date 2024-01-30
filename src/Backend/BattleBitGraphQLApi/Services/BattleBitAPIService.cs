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
        => await _memoryCache.GetOrCreateAsync(
            key: nameof(BattleBitAPIServerInfo),
            factory: async cacheEntry =>
            {
                cacheEntry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(2);

                _logger.LogInformation("Fetching server BattleBit servers");

                var httpClient = _httpClientFactory.CreateClient(HttpClientName.BattleBitAPI);

                return await httpClient.GetFromJsonAsync<IReadOnlyList<BattleBitAPIServerInfo>>(
                        requestUri: "Servers/GetServerList",
                        options: new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true
                        },
                        cancellationToken: cancellationToken)
                    ?? null!;
            })
            .ContinueWith(taskResult
                => taskResult.Result?.Select(x => new ServerInfo
                {
                    AntiCheat = x.AntiCheat.CastTo(AntiCheatType.None),
                    Build = x.Build,
                    DayNight = x.DayNight.CastTo(DayNightType.None),
                    GameMode = x.Gamemode.CastTo(GameModeType.None),
                    HasPassword = x.HasPassword,
                    Hz = x.Hz,
                    IsOfficial = x.IsOfficial,
                    LastUpdated = x.LastUpdated,
                    Map = x.Map.CastTo(MapType.None),
                    MapSize = x.MapSize.CastTo(MapSizeType.None),
                    MaxPlayers = x.MaxPlayers,
                    Name = x.Name,
                    Players = x.Players,
                    QueuePlayers = x.QueuePlayers,
                    Region = x.Region.CastTo(RegionType.None),
                    RawAPIData = new()
                    {
                        AntiCheatTypeString = x.AntiCheat,
                        DayNightTypeString = x.DayNight,
                        GameModeTypeString = x.Gamemode,
                        MapSizeTypeString = x.MapSize,
                        MapTypeString = x.Map,
                        RegionTypeString = x.Region
                    }
                }).ToList()) ?? null!;

    public async Task<IReadOnlyList<StatisticsObject>> GetMostXPAsync(
        CancellationToken cancellationToken = default)
        => await GetLeaderboardAsync(cancellationToken)
            .ContinueWith(taskResult => taskResult.Result.MostXP.ToList());

    public async Task<IReadOnlyList<StatisticsObject>> GetMostHealsAsync(
        CancellationToken cancellationToken = default)
        => await GetLeaderboardAsync(cancellationToken)
            .ContinueWith(taskResult => taskResult.Result.MostHeals.ToList());

    public async Task<IReadOnlyList<StatisticsObject>> GetMostRevivesAsync(
        CancellationToken cancellationToken = default)
        => await GetLeaderboardAsync(cancellationToken)
            .ContinueWith(taskResult => taskResult.Result.MostRevives.ToList());

    public async Task<IReadOnlyList<StatisticsObject>> GetMostVehiclesDestroyedAsync(
        CancellationToken cancellationToken = default)
        => await GetLeaderboardAsync(cancellationToken)
            .ContinueWith(taskResult => taskResult.Result.MostVehiclesDestroyed.ToList());

    public async Task<IReadOnlyList<StatisticsObject>> GetMostVehicleRepairsAsync(
        CancellationToken cancellationToken = default)
        => await GetLeaderboardAsync(cancellationToken)
            .ContinueWith(taskResult => taskResult.Result.MostVehicleRepairs.ToList());

    public async Task<IReadOnlyList<StatisticsObject>> GetMostRoadKillsAsync(
        CancellationToken cancellationToken = default)
        => await GetLeaderboardAsync(cancellationToken)
            .ContinueWith(taskResult => taskResult.Result.MostRoadKills.ToList());

    public async Task<IReadOnlyList<StatisticsObject>> GetMostLongestKillAsync(
        CancellationToken cancellationToken = default)
        => await GetLeaderboardAsync(cancellationToken)
            .ContinueWith(taskResult => taskResult.Result.MostLongestKill.ToList());

    public async Task<IReadOnlyList<StatisticsObject>> GetMostObjectivesCompletedAsync(
        CancellationToken cancellationToken = default)
        => await GetLeaderboardAsync(cancellationToken)
            .ContinueWith(taskResult => taskResult.Result.MostObjectivesComplete.ToList());

    public async Task<IReadOnlyList<StatisticsObject>> GetMostKillsAsync(
        CancellationToken cancellationToken = default)
        => await GetLeaderboardAsync(cancellationToken)
            .ContinueWith(taskResult => taskResult.Result.MostKills.ToList());

    public async Task<IReadOnlyList<TopClanObject>> GetTopClans(
        CancellationToken cancellationToken = default)
        => await GetLeaderboardAsync(cancellationToken)
            .ContinueWith(taskResult => taskResult.Result.TopClans.ToList());

    private async Task<LeaderBoardInfo> GetLeaderboardAsync(
        CancellationToken cancellationToken = default)
        => await _memoryCache.GetOrCreateAsync(
            key: nameof(LeaderBoardInfo),
            factory: async cacheEntry =>
            {
                cacheEntry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(2);

                _logger.LogInformation("Fetching BattleBit leaderboard");

                var httpClient = _httpClientFactory.CreateClient(HttpClientName.BattleBitAPI);

                var result = await httpClient.GetFromJsonAsync<IReadOnlyList<BattleBitAPILeaderBoardInfo>>(
                        requestUri: "Leaderboard/Get",
                        options: new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true
                        },
                        cancellationToken: cancellationToken)
                    ?? null!;

                return new LeaderBoardInfo
                {
                    TopClans = result
                        .SelectMany(e => e.TopClans)
                        .OrderByDescending(e => int.TryParse(e.XP, out var xp) ? xp : 0)
                        .Select((e, i) => new TopClanObject
                        {
                            ClanName = e.Clan,
                            Tag = e.Tag,
                            XP = int.TryParse(e.XP, out var xp) ? xp : 0,
                            MaxPlayers = int.TryParse(e.MaxPlayers, out var maxPlayers) ? maxPlayers : 0,
                            Position = i + 1
                        })
                        .OrderBy(e => e.Position)
                        .ToList(),

                    MostXP = result
                        .SelectMany(e => e.MostXP)
                        .Select((e, i) => new StatisticsObject
                        {
                            PlayerName = e.Name,
                            Value = int.TryParse(e.Value, out var val) ? val : 0,
                            Position = i + 1
                        })
                        .OrderByDescending(e => e.Value)
                        .ToList(),

                    MostHeals = result
                        .SelectMany(e => e.MostHeals)
                        .Select((e, i) => new StatisticsObject
                        {
                            PlayerName = e.Name,
                            Value = int.TryParse(e.Value, out var val) ? val : 0,
                            Position = i + 1
                        })
                        .OrderByDescending(e => e.Value)
                        .ToList(),

                    MostRevives = result
                        .SelectMany(e => e.MostRevives)
                        .Select((e, i) => new StatisticsObject
                        {
                            PlayerName = e.Name,
                            Value = int.TryParse(e.Value, out var val) ? val : 0,
                            Position = i + 1
                        })
                        .OrderByDescending(e => e.Value)
                        .ToList(),

                    MostVehiclesDestroyed = result
                        .SelectMany(e => e.MostVehiclesDestroyed)
                        .Select((e, i) => new StatisticsObject
                        {
                            PlayerName = e.Name,
                            Value = int.TryParse(e.Value, out var val) ? val : 0,
                            Position = i + 1
                        })
                        .OrderByDescending(e => e.Value)
                        .ToList(),

                    MostVehicleRepairs = result
                        .SelectMany(e => e.MostVehicleRepairs)
                        .Select((e, i) => new StatisticsObject
                        {
                            PlayerName = e.Name,
                            Value = int.TryParse(e.Value, out var val) ? val : 0,
                            Position = i + 1
                        })
                        .OrderByDescending(e => e.Value)
                        .ToList(),

                    MostRoadKills = result
                        .SelectMany(e => e.MostRoadKills)
                        .Select((e, i) => new StatisticsObject
                        {
                            PlayerName = e.Name,
                            Value = int.TryParse(e.Value, out var val) ? val : 0,
                            Position = i + 1
                        })
                        .OrderByDescending(e => e.Value)
                        .ToList(),

                    MostLongestKill = result
                        .SelectMany(e => e.MostLongestKill)
                        .Select((e, i) => new StatisticsObject
                        {
                            PlayerName = e.Name,
                            Value = int.TryParse(e.Value, out var val) ? val : 0,
                            Position = i + 1
                        })
                        .OrderByDescending(e => e.Value)
                        .ToList(),

                    MostObjectivesComplete = result
                        .SelectMany(e => e.MostObjectivesComplete)
                        .Select((e, i) => new StatisticsObject
                        {
                            PlayerName = e.Name,
                            Value = int.TryParse(e.Value, out var val) ? val : 0,
                            Position = i + 1
                        })
                        .OrderByDescending(e => e.Value)
                        .ToList(),

                    MostKills = result
                        .SelectMany(e => e.MostKills)
                        .Select((e, i) => new StatisticsObject
                        {
                            PlayerName = e.Name,
                            Value = int.TryParse(e.Value, out var val) ? val : 0,
                            Position = i + 1
                        })
                        .OrderByDescending(e => e.Value)
                        .ToList(),
                };
            })
            .ContinueWith(taskResult => taskResult.Result ?? null!);
}