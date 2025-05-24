using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

using WaterQuality.DashBoard.Shared.Services;
using WaterQuality.DashBoard.Web.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Add device-specific services used by the WaterQuality.DashBoard.Shared project
builder.Services.AddSingleton<IFormFactor, FormFactor>();

await builder.Build().RunAsync();
