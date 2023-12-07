using BattleBitProxy.ServerExplorer;

using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

using MudBlazor.Services;

using ServerExplorer;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.Configure<FrontendOptions>(
    builder.Configuration.GetSection(FrontendOptions.Frontend));

var configuration = builder.Configuration
        .GetSection(FrontendOptions.Frontend)
        .Get<FrontendOptions>()
    ?? null!;

builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
});

builder.Services
    .AddMudServices();

builder.Services
    .AddBattlebitClient()
    .ConfigureHttpClient(client => client.BaseAddress = new Uri(configuration.BackendUrl))
    .ConfigureWebSocketClient(client => client.Uri = new Uri(configuration.BackendWebsocketUrl));

await builder.Build().RunAsync();