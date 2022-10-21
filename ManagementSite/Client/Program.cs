using Blazored.LocalStorage;
using Management.Application.Authentication;
using Management.Application.Interfaces;
using Management.Application.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Services;
using System;
using System.Net.Http;
using System.Threading.Tasks;


namespace ManagementSite.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddOptions();
            builder.Services.AddAuthorizationCore();

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddMudServices();
            builder.Services.AddBlazoredLocalStorage();

            builder.Services.AddTransient<IAccountService, AccountService>();
            builder.Services.AddTransient<IManagerService, ManagerService>();
            builder.Services.AddTransient<ICustomerService, CustomerService>();

            builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();


            await builder.Build().RunAsync();
        }
    }
}
