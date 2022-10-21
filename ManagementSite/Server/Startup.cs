using Blazored.LocalStorage;
using Management.Application.Dto.MappInitialiser;
using Management.Application.Interfaces;
using Management.Application.Services;
using Management.Domain.Models;
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
            services.AddAuthenticationCore();
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            });

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddDbContext<CommonDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("CommonDbConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.SignIn.RequireConfirmedEmail = false;
            }).AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(option =>
            {
                option.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration["JwtIssuer"],
                    ValidAudience = Configuration["JwtAudience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["SecretKey"]))
                };
            });

            // ForgotPassword & ResetPassword 토큰 제한시간, 즉 24시간내에 비밀번호를 바꿔야 된다는 뜻.
            services.Configure<DataProtectionTokenProviderOptions>(options =>
            {
                options.TokenLifespan = TimeSpan.FromHours(24);
            });
           
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder => builder
                       .AllowAnyOrigin()
                       .AllowAnyHeader()
                       .AllowAnyMethod());
            });

            services.AddControllers().AddNewtonsoftJson();
            services.AddAutoMapper(typeof(MappInitialiser));
            services.AddBlazoredLocalStorage();

            services.Configure<SmtpOptions>(Configuration.GetSection("Smtp"));
            services.AddSingleton<IEmailSender, EmailSender>();

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
                //endpoints.MapFallbackToPage("/ResetPassword/{userid}/{token}", "/ResetPassword.html");
                endpoints.MapFallbackToFile("index.html");
            });
        }
    }
}
