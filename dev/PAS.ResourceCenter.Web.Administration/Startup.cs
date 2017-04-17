﻿#region Using
 
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PAS.ResourceCenter.Library.DataAccess.Repositories;
using PAS.ResourceCenter.Library.DataAccess.Models;
using PAS.ResourceCenter.Web.Administration.Helpers;
using PAS.ResourceCenter.Web.Administration.Models;
using PAS.ResourceCenter.Web.Administration.Services;

#endregion

namespace PAS.ResourceCenter.Web.Administration
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            // Set up configuration sources.
            var builder = new ConfigurationBuilder()
                 .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true);

            if (env.IsDevelopment())
            {
                // For more details on using the user secret store see http://go.microsoft.com/fwlink/?LinkID=532709
                //builder.AddUserSecrets();
            }
            
            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add our global app settings; this approach auto-maps setting key-value pairs to properties of the same name
            services.Configure<Settings>(Configuration);
            services.AddOptions();

            // Add framework services
            services.AddEntityFrameworkSqlServer()
                .AddDbContext<ApplicationDbContext>(options => 
                options.UseSqlServer(Configuration["Data:DefaultConnection:ConnectionString"]));
            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                // We override the default so we can use our demo user
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 6;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
            }).AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
            services.AddMvc();

            // Add application services
            services.AddTransient<DatabaseInitializer>();
            services.AddTransient<IEmailSender, AuthMessageSender>();
            services.AddTransient<ISmsSender, AuthMessageSender>();
            
            // Add repository services
            services.AddScoped<ISectorsRepository, SectorsRepository>();
            services.AddTransient<bbwContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public async void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, DatabaseInitializer initializer)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");

                // For more details on creating database during deployment see http://go.microsoft.com/fwlink/?LinkID=615859
                try
                {
                    using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
                    {
                        serviceScope.ServiceProvider.GetService<ApplicationDbContext>().Database.Migrate();
                    }
                }
                catch
                {
                    // ignored
                }
            }

            ///app.UseIISPlatformHandler(options => options.AuthenticationDescriptions.Clear());
            app.UseStaticFiles();
            app.UseIdentity();

            // To configure external authentication please see http://go.microsoft.com/fwlink/?LinkID=532715

            app.UseMvc(routes => { routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{id?}"); });

            // Seed our database with initial user(s)
            await initializer.SeedAsync();
        }
        
    }
}