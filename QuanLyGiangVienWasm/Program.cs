using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using QuanLyGiangVienWasm.Services;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyGiangVienWasm
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddTransient<IGiaoVienApiClient, GiaoVienApiClient>();
            builder.Services.AddTransient<ITaiKhoanApiClient, TaiKhoanApiClient>();

            builder.Services.AddScoped(sp => new HttpClient 
            { 
                BaseAddress = new Uri(builder.Configuration["BackendApiUrl"]) 
            });

            await builder.Build().RunAsync();
        }
    }
}
