using System.Text.Json;

using BattleBitProxy.Backend.BattleBitGraphQLApi.Extensions;
using BattleBitProxy.Backend.BattleBitGraphQLApi.Models.BattleBitAPIModels;
using BattleBitProxy.Backend.BattleBitGraphQLApi.Models.GraphQLModels;
using BattleBitProxy.Backend.BattleBitGraphQLApi.Models.GraphQLModels.Types;
using BattleBitProxy.Backend.BattleBitGraphQLApi.Types;

namespace BattleBitProxy.Backend.BattleBitGraphQLApi.Services;

public class BattleBitAPIService
{
    private readonly ILogger<BattleBitAPIService> _logger;
    private readonly IHttpClientFactory _httpClientFactory;

    public BattleBitAPIService(
        ILogger<BattleBitAPIService> logger,
        IHttpClientFactory httpClientFactory)
    {
        _logger = logger;
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IReadOnlyList<ServerInfo>> GetAllServersAsync(
        CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Fetching server BattleBit servers");

        var httpClient = _httpClientFactory.CreateClient(HttpClientName.BattleBitAPI);

        var requestResponse = await httpClient.GetAsync(
            requestUri: "Servers/GetServerList",
            cancellationToken: cancellationToken);

        var responseObject = await ParseResponse<IReadOnlyList<BattleBitAPIServerInfo>>(requestResponse);

        return responseObject.Select(x => new ServerInfo
        {
            AntiCheat = x.AntiCheat.CastTo<AntiCheatType>(),
            Build = x.Build,
            DayNight = x.DayNight.CastTo<DayNightType>(),
            GameMode = x.Gamemode.CastTo<GameModeType>(),
            HasPassword = x.HasPassword,
            Hz = x.Hz,
            IsOfficial = x.IsOfficial,
            Map = x.Map.CastTo<MapType>(),
            MapSize = x.MapSize.CastTo<MapSizeType>(),
            MaxPlayers = x.MaxPlayers,
            Name = x.Name,
            Players = x.Players,
            QueuePlayers = x.QueuePlayers,
            Region = x.Region.CastTo<RegionType>()
        }).ToList();
    }

    private async Task<TObject> ParseResponse<TObject>(
        HttpResponseMessage message)
    {
        if (message.IsSuccessStatusCode is false)
            return default!;

        var responseContent = await message.Content.ReadAsStringAsync();

        return JsonSerializer.Deserialize<TObject>(
            json: responseContent,
            options: new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            }) ?? default!;
    }
}