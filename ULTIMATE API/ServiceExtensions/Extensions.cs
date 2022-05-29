using contracts;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace ULTIMATE_API.Extensions
{
    public static class ServiceExtension
    {
        // an extension service class that has  methods for configuring cors and IIS integration when deployment 
       public static void ConfigureCors(this IServiceCollection services) =>

         services.AddCors(options =>
         {
             options.AddPolicy("CorsPolicy", builder =>
             builder.AllowAnyOrigin()
             .AllowAnyMethod()
             .AllowAnyHeader());
         });

    public static void ConfigureIISIntegration(this IServiceCollection services) =>
     services.Configure<IISOptions>(options => 
     {
        });

        public static void ConfigureSwager(this IServiceCollection services) => services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "ULTIMATE_API", Version = "v1" });
        });
    public static void ConfigureLogger(this IServiceCollection services) => services.AddScoped<ILoggerManager, LoggerManager>();
    }

}
