using Management.Application.Dto.MappInitialiser;
using Management.Application.Interfaces;
using Management.Application.Services;
using Management.Domain.Models;
using ManagementDbContext.DbContext;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Linq;

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
            services.AddAuthentication().AddCookie();

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.SignIn.RequireConfirmedEmail = false;
            }).AddRoles<IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            });

            services.AddControllers().AddNewtonsoftJson();
            services.AddAutoMapper(typeof(MappInitialiser));

            //services.Configure<IdentityOptions>(options =>
            //{
            //    options.Password.RequiredLength = 3;
            //    options.Password.RequireDigit = true;
            //    options.Password.RequireNonAlphanumeric = false;
            //    options.Password.RequireLowercase = true;
            //    options.Password.RequireUppercase = true;
            //    options.User.RequireUniqueEmail = true;

            //    //이메일 컨펌 해야 로그인 가능 유무 체크
            //    // options.SignIn.RequireConfirmedEmail = true;

            //    //5번까지 시도 가능
            //    //options.Lockout.MaxFailedAccessAttempts = 5;

            //    //30분 후 잠김
            //    //options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
            //});
            services.AddMvcCore();
            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddHttpClient();

            services.AddTransient<IAccountService, AccountService>();
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
            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
                endpoints.MapRazorPages();
                //endpoints.MapControllers();
                endpoints.MapFallbackToFile("index.html");
            });
        }
    }
}
