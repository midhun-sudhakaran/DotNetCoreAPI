using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace CoreWebAPI
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            //services.AddSingleton<IUtil, Util>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Use(async (context, next) =>
            {
                logger.LogInformation("Middleware 1: Incoming request");
                context.Request.Headers.Add("TestHeader", "Value");
                await next();
                logger.LogInformation("Middleware 1: Outgoing response");
            });

            app.Use(async (context, next) =>
            {
                logger.LogInformation("Middleware 2: Incoming request");
                await next();
                logger.LogInformation("Middleware 2: Outgoing response");
            });

            app.UseMvc();

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Middleware 3 (Terminal Middleware): Request and response handled");
                logger.LogInformation("Middleware 3 (Terminal Middleware): Request and response handled");
            });

        }
    }
}
