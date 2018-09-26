using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using FacilityMgmt.Api.Interfaces;
using FacilityMgmt.Api.Services;
using FacilityMgmt.DAL.Common.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace FacilityMgmt.Api
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "FacilityManagement API", Version = "v1" });
                // https://github.com/domaindrivendev/Swashbuckle.AspNetCore#add-security-definitions-and-requirements
            });

            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "wwwRoot";
            });
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterType<AppSettings>().As<IAppSettings>().SingleInstance().OnActivated(e => e.Instance.Validate());
            builder.RegisterType<GracenoteConnectorMock>().As<IGracenoteConnector>().SingleInstance();
            builder.RegisterInstance(Serilog.Log.Logger);
            //builder.RegisterInstance(MappingConfiguration.Create());

            //services.AddSingleton<Func<IAppSettings, SqlConnection>>((appSettings) => new SqlConnection(appSettings.FacilityConnectionString));
            //services.AddSingleton<Func<IAppSettings, IDbConfiguration>>((appSettings) => new DbConfiguration(appSettings.FacilityConnectionString));
            builder.Register<IDbConfiguration>(ctx => new DbConfiguration(ctx.Resolve<IAppSettings>().FacilityConnectionString)).SingleInstance();
            // The following configurations are exclusive
            //TvListings.DAL.EF.ModuleLoader.Configure(builder);
            FacilityMgmt.DAL.Dapper.ModuleLoader.Configure(builder);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app
                .UseSwagger()
                .UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "FacilityManagement API V1");
                })
                .UseMvc(routes =>
                {
                    routes.MapRoute(
                        name: "default",
                        template: "{controller}/{action=Index}/{id?}");
                })
                .UseSpa(spa =>
                {
                    // To learn more about options for serving an Angular SPA from ASP.NET Core,
                    // see https://go.microsoft.com/fwlink/?linkid=864501

                    spa.Options.SourcePath = "..\\FacilityMgmt.AdminUI";

                    if (env.IsDevelopment())
                    {
                        spa.UseAngularCliServer(npmScript: "start");
                    }
                });
        }
    }
}
