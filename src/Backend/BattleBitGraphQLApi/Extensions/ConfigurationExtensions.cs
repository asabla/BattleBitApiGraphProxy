using BattleBitProxy.Backend.BattleBitGraphQLApi.Models.Settings;

using FluentValidation;

namespace BattleBitProxy.Backend.BattleBitGraphQLApi.Extensions;

internal static class ConfigurationExtensions
{
    public static WebApplicationBuilder ConfigurationSetup(
        this WebApplicationBuilder builder)
    {
        builder.Configuration
            .AddJsonFile("appsettings.json",
                optional: true,
                reloadOnChange: true)
            .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json",
                optional: true,
                reloadOnChange: true);

        // Fluent validation of configuration file
        builder.Services.AddScoped<IValidator<ApiSettings>, ApiSettingsValidator>();
        builder.Services.AddOptions<ApiSettings>()
            .BindConfiguration(nameof(ApiSettings))
            .ValidateWithFluent()
            .ValidateOnStart();

        return builder;
    }
}