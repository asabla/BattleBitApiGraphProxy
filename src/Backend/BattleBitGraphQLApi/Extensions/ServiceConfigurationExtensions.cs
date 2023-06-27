using BattleBitProxy.Backend.BattleBitGraphQLApi.Services;

namespace BattleBitProxy.Backend.BattleBitGraphQLApi.Extensions;

public static class ServiceConfigurationExtensions
{
    public static WebApplicationBuilder ConfigureServices(
        this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<BattleBitAPIService>();

        return builder;
    }
}