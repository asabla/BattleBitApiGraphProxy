using BattleBitProxy.Backend.BattleBitGraphQLApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder
    .ConfigurationSetup()
    .ConfigureServices()
    .ConfigureGraphQLServer();

var app = builder.Build();

app.UseHttpsRedirection();

// TODO: make configuration of this prettier
app.UseCors(options => options
        .WithOrigins("https://localhost:7024")
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials());

app.MapGraphQL();

// Can be used for health check (just return 200 OK)
app.MapGet("/", () => StatusCodes.Status200OK);

await app.RunWithGraphQLCommandsAsync(args);