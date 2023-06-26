using BattleBitProxy.Backend.BattleBitGraphQLApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Load configuration and setup application
builder
    .ConfigurationSetup()
    .ConfigureGraphQLServer();

var app = builder.Build();

app.UseHttpsRedirection();

app.MapGraphQL();

// Can be used for health check (just return 200 OK)
app.MapGet("/", () => StatusCodes.Status200OK);

app.Run();
