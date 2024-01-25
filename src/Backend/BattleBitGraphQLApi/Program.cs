using BattleBitProxy.Backend.BattleBitGraphQLApi.Extensions;
using BattleBitProxy.Backend.BattleBitGraphQLApi.Models.Settings;

var builder = WebApplication.CreateBuilder(args);

builder
    .ConfigurationSetup()
    .ConfigureServices()
    .ConfigureGraphQLServer();

var settings = builder.Configuration.Get<ApiSettings>() ?? null!;

var app = builder.Build();

// app.UseHttpsRedirection();

// TODO: make configuration of this prettier
app.UseCors(options
        => options.WithOrigins(settings.Backend.FrontendUrls.ToArray())
    .AllowAnyHeader()
    .AllowAnyMethod()
    .AllowCredentials());

app.MapGraphQL();

// Can be used for health check (just return 200 OK)
app.MapGet("/", () => StatusCodes.Status200OK);

await app.RunWithGraphQLCommandsAsync(args);