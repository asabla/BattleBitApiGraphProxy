namespace BattleBitProxy.Backend.BattleBitGraphQLApi.Models.Settings;

// TODO: Add required settings if needed
internal class ApiSettings
{
    public BackendSettings Backend { get; set; } = null!;
}

internal class BackendSettings
{
    public IEnumerable<string> FrontendUrls { get; set; } = null!;
}