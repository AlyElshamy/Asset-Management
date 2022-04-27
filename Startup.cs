using AssetProject.Data;
using AssetProject.Models;
using Email;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Localization;
using Newtonsoft.Json.Serialization;
using NToastNotify;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace AssetProject
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLocalization(options => options.ResourcesPath = "Resources");

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddDbContext<AssetContext>(options =>
               options.UseSqlServer(
                   Configuration.GetConnectionString("DefaultConnection")));

            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddIdentity<ApplicationUser,IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Identity/Account/Login";
                options.AccessDeniedPath = "/Identity/Account/AccessDenied";
            });

            services.AddTransient<IEmailSender, EmailSender>();
            services.AddRazorPages().AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);
            services.AddRazorPages().AddNToastNotifyToastr(new ToastrOptions()
            {
                ProgressBar = true,
                PositionClass=ToastPositions.TopRight,
                PreventDuplicates = true,
                CloseButton = true
            });

            services.AddRazorPages().AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null).AddDataAnnotationsLocalization(
                options =>
                {
                    var type = typeof(SharedResource);
                    var assembblyName = new AssemblyName(type.GetTypeInfo().Assembly.FullName);
                    var factory = services.BuildServiceProvider().GetService<IStringLocalizerFactory>();
                    var localizer = factory.Create("SharedResource", assembblyName.Name);
                    options.DataAnnotationLocalizerProvider = (t, f) => localizer;
                }
                );

            services.AddControllers().AddDataAnnotationsLocalization(
                options =>
                {
                    var type = typeof(SharedResource);
                    var assembblyName = new AssemblyName(type.GetTypeInfo().Assembly.FullName);
                    var factory = services.BuildServiceProvider().GetService<IStringLocalizerFactory>();
                    var localizer = factory.Create("SharedResource", assembblyName.Name);
                    options.DataAnnotationLocalizerProvider = (t, f) => localizer;
                }


                );
            services.AddControllersWithViews().AddDataAnnotationsLocalization(
                options =>
                {
                    var type = typeof(SharedResource);
                    var assembblyName = new AssemblyName(type.GetTypeInfo().Assembly.FullName);
                    var factory = services.BuildServiceProvider().GetService<IStringLocalizerFactory>();
                    var localizer = factory.Create("SharedResource", assembblyName.Name);
                    options.DataAnnotationLocalizerProvider = (t, f) => localizer;
                }

                );
            services.AddMvc(options => options.EnableEndpointRouting = false);
         
            //services.AddAntiforgery(o => o.HeaderName = "XSRF-TOKEN");
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            var supportedCultures = new[]
           {
                new CultureInfo("en-US"),

                new CultureInfo("ar-EG")

            };

            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("en-Us"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            });
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapRazorPages();
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

        }
    }
}
