using Blazored.LocalStorage;
using CommonDatabase.Models.Accessories;
using CommonDatabase.Models.TotalItems;
using Management.Application.Authentication;
using Management.Application.ViewModel.CommonDb.TotalItems;
using Management.Application.Interfaces;
using Management.Application.Interfaces.CommonDb;
using Management.Application.Interfaces.CommonDb.GenericRepository;
using Management.Application.Services;
using Management.Application.Services.CommonDb;
using Management.Application.Services.CommonDb.GenericService;
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

            builder.Services.AddTransient<IAccountRepository, AccountService>();
            builder.Services.AddTransient<IManagerRepository, ManagerService>();
            builder.Services.AddTransient<ICustomerRepository, CustomerService>();
            builder.Services.AddTransient<IGetItemRepository, GetItemService>();
            builder.Services.AddTransient<IChartRepository, ChartService>();
            builder.Services.AddTransient<IUpdateItemRepository, UpdateItemService>();
            builder.Services.AddTransient<ICreateItemRepository, CreateItemService>();

            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericService<>));

            builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();


            await builder.Build().RunAsync();
        }
    }
}
