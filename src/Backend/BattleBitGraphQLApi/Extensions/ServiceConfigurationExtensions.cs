using BattleBitProxy.Backend.BattleBitGraphQLApi.Services;
using BattleBitProxy.Backend.BattleBitGraphQLApi.Types;

namespace BattleBitProxy.Backend.BattleBitGraphQLApi.Extensions;

public static class ServiceConfigurationExtensions
{
    public static WebApplicationBuilder ConfigureServices(
        this WebApplicationBuilder builder)
    {
        // Register CORS services
        builder.Services.AddCors();

        // Register memory cache with tracking statistics enabled
        builder.Services.AddMemoryCache(opt => opt.TrackStatistics = true);

        // Register needed BattleBitAPI services
        builder.Services.AddHttpClient(HttpClientName.BattleBitAPI, opt
            => opt.BaseAddress = new Uri("https://publicapi.battlebit.cloud"));

        builder.Services.AddScoped<BattleBitAPIService>();

        return builder;
    }
}