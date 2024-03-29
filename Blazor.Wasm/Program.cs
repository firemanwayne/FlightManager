using Blazor.Wasm;
using Blazor.Wasm.Clients;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.SignalR.Client;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddSingleton<FlightHttpClient>();

builder.Services
    .AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) })
    .AddHttpClient<FlightHttpClient>(c => c.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));

builder.Services.AddHttpClient("Web.Server.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
    .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

builder.Services.AddSingleton(sp =>
{
    var navigationManager = sp.GetRequiredService<NavigationManager>();

    return new HubConnectionBuilder()
      .WithUrl(navigationManager.ToAbsoluteUri("/flighthub"))
      .WithAutomaticReconnect()
      .Build();
});

builder.Services.AddApiAuthorization();

await builder
    .Build()
    .RunAsync();
