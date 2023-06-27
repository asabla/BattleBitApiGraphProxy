using System.Text.Json;

using BattleBitProxy.Backend.BattleBitGraphQLApi.Models.BattleBit;

namespace BattleBitProxy.Backend.BattleBitGraphQLApi.Services;

public class BattleBitAPIService
{
    private readonly ILogger<BattleBitAPIService> _logger;
    private readonly IHttpClientFactory _httpClientFactory;

    private const string HttpClientName = "BattleBitAPI";

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

        var httpClient = _httpClientFactory.CreateClient(HttpClientName);

        var requestResponse = await httpClient.GetAsync(
            requestUri: "Servers/GetServerList",
            cancellationToken: cancellationToken);

        var result = await ParseResponse<IReadOnlyList<ServerInfo>>(requestResponse);

        return result;
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