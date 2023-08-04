using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

using ServerExplorer;

using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services
    .AddMudServices();

builder.Services
    .AddBattlebitClient()
    .ConfigureHttpClient(client => client.BaseAddress = new Uri("https://localhost:7113/graphql"))
    .ConfigureWebSocketClient(client => client.Uri = new Uri("ws://localhost:7113/graphql"));

await builder.Build().RunAsync();
