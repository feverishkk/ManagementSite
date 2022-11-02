using Blazored.LocalStorage;
using Management.Application.Interfaces;
using Management.Application.Interfaces.CommonDb.GenericRepository;
using Management.Application.Services;
using Management.Application.Services.CommonDb.GenericService;
using Management.Domain.Models;
using Management.Infrastructure.IoC;
using Management.Infrastructure.Shared.EmailSender;
using ManagementDbContext.DbContext;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace ManagementSite.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddIdentityDI();
            services.AddJwtDI();

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddDbContext<CommonDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("CommonDbConnection")));

            services.AddMvc().AddControllersAsServices();

            services.AddControllers().AddNewtonsoftJson();
            services.AddBlazoredLocalStorage();

            services.AddHttpContextAccessor();
            services.AddScoped<HttpContextAccessor>();

            services.Configure<SmtpOptions>(Configuration.GetSection("Smtp"));
            services.AddSingleton<IEmailSenderRepository, EmailSender>();
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericService<>));

            services.AddServerSideBlazor();
            services.AddMvcCore();
            services.AddControllersWithViews();

            services.AddRazorPages();
            services.AddHttpClient();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseCors("CorsPolicy");
            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
                endpoints.MapRazorPages();
                endpoints.MapFallbackToFile("index.html");
            });
        }
    }
}
