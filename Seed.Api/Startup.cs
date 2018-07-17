using Common.API;
using Common.Domain.Base;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Seed.Application.Config;
using Seed.Data.Context;
using System.Globalization;
using Microsoft.AspNetCore.Localization;
using Common.API.Extensions;
using System.Collections.Generic;
using Seed.CrossCuting;

namespace Seed.Api
{
    public class Startup
    {
		private readonly IHostingEnvironment _env;

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
			this._env = env;
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
			//Camelcase para json
            services.AddMvc()
			.AddJsonOptions(options =>
			{
				options.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
			});

            services.AddDbContext<DbContextSeed>(
             options => options.UseSqlServer(
                 Configuration
                    .GetSection("ConfigConnectionString:Default").Value));

            services.AddDistributedRedisCache(options =>
            {
                options.Configuration = Configuration.GetSection("RedisConnStrings:Seed").Value;
                options.InstanceName = "Seed";
            });

            services.Configure<ConfigSettingsBase>(Configuration.GetSection("ConfigSettings"));
            services.AddSingleton<IConfiguration>(Configuration);
			services.AddSingleton(new EnviromentInfo
            {
                RootPath = this._env.ContentRootPath
            });

			// Config AuthorityEndPoint SSO
			 services.AddAuthentication("Bearer")
			.AddIdentityServerAuthentication(options =>
			{
				options.Authority = Configuration.GetSection("ConfigSettings:AuthorityEndPoint").Value;
				options.RequireHttpsMetadata = false;
				options.ApiName = "ssosa";
			});


            // Add cross-origin resource sharing services Configurations
            Cors.Enable(services);

            // Add application services.
            ConfigContainerSeed.Config(services);			

            // Add framework services.
            services.AddMvc(options => { options.ModelBinderProviders.Insert(0, new DateTimePtBrModelBinderProvider()); })
            .AddJsonOptions(options =>
            {
                options.SerializerSettings.Converters.Add(new DateTimePtBrConverter());
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IOptions<ConfigSettingsBase> configSettingsBase)
        {

			loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseDeveloperExceptionPage();

            var supportedCultures = new[]
            {
                new CultureInfo("pt-BR"),
            };

            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("pt-BR"),
                // Formatting numbers, dates, etc.
                SupportedCultures = supportedCultures,
                // UI strings that we have localized.
                SupportedUICultures = supportedCultures
            });
        	
			app.UseAuthentication();
            app.AddTokenMiddlewareCustom();
            app.UseMvc();
	    	app.UseCors("AllowAnyOrigin");
            AutoMapperConfigSeed.RegisterMappings();
        }

    }
}
