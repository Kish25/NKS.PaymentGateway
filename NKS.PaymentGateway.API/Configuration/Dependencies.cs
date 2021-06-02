using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

namespace NKS.PaymentGateway.API.Configuration
{
    public static class Dependencies
    {
        public static IServiceCollection AddAPIConfiguration(this IServiceCollection services,IConfiguration config)
        {
            
            var swaggerConfig = config.GetSection("SwaggerConfiguration").Get<Swagger>();
            
            services
                .AddMvcCore()
                .AddMvcOptions(options =>
                {
                    //options.Filters.Add<UnitOfWork>(1);
                    //options.Filters.Add<LogRequestTimeFilterAttribute>();
                });

            services.AddSwaggerGen(options =>
            {
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlCommentsPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

                options.IncludeXmlComments(xmlCommentsPath);
                options.SwaggerDoc($"v{swaggerConfig.Version}", new OpenApiInfo
                {
                    Title = swaggerConfig.Title,
                    Version = $"v{swaggerConfig.Version}",
                    Description = swaggerConfig.Description,

                });
                options.EnableAnnotations();
            });
            return services;
        }
    }
}
