using AppBlazorWebAss;
using AppBlazorWebAss.Data.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddHttpClient("IJGZAPI", client =>
{
    client.BaseAddress = new Uri("https://localhost:7157/");
});

builder.Services.AddScoped<ProductIJGZService>();
await builder.Build().RunAsync();
