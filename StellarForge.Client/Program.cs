using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using StellarForge.Client;
using StellarForge.Client.Services;
using StellarForge.Client.Services.Interfaces;
using StellarForge.Shared.Services.Interfaces;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Register services
builder.Services.AddSingleton<IGameStateService, GameStateService>();
builder.Services.AddSingleton<GameLoopService>();
builder.Services.AddScoped<ISaveService, SaveService>();

builder.Services.AddHttpClient("server");

await builder.Build().RunAsync();
