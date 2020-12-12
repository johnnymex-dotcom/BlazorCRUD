using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;


namespace BlazorCRUD.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            //***************
            //builder.Services.AddSingleton<UnhandledExceptionLogger>();

            //***************

            builder.Services.AddSingleton<BlazorTimer>();
            builder.Services.AddTransient<System.Timers.Timer>();


            //*********
            //// Change end of Main() from await builder.Build().RunAsync(); to:
            //var host = builder.Build();
            //// Make sure UnhandledExceptionLogger is created at startup:
            //host.Services.GetService<UnhandledExceptionLogger>();

            //**********

            await builder.Build().RunAsync();
            
        }
    }
}
