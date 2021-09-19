using System;
using System.Net.Http;
using System.Threading.Tasks;
using FrostyStarsCompanion.Web.Model.Frostgrave;
using FrostyStarsCompanion.Web.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace FrostyStarsCompanion.Web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(
                _ => new HttpClient {BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)});
            builder.Services.AddScoped<IDataStore<Warband>>(sp => new WarbandDataStore(sp.GetService<HttpClient>()));

            await builder.Build().RunAsync();
        }
    }
}