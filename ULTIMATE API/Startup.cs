using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using ULTIMATE_API.Extensions;

namespace ULTIMATE_API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(),"/Nlog.config"));
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureLogger();
            services.ConfigureCors();
            services.ConfigureIISIntegration();
            services.AddControllers();
            services.ConfigureSwager();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ULTIMATE_API v1"));
            }
            else
            {

                // adds a header requirement for the http request Strict Transport Security Header ( THE SITE SHOULD ALWAYS BE ACCESSED USING HTTPS)
                app.UseHsts();
            }

            // enables static files serving  enables using static files for the request. If
           // we don’t set a path to the static files directory, it will use a wwwroot
            //folder in our project by default.
            app.UseStaticFiles();

            // USES OUR SERVICE FOR CORS POLICY THAT WAS DEFINED IN THE EXTENSION FOLDER
            app.UseCors("CorsPolicy");

            // more headers mapping and fowarding  app.UseForwardedHeaders() will forward proxy headers to the
           // current request. This will help us during application deployment.
                        app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.All
            });
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
