﻿namespace NKS.Payments.API.Configuration
{
    using System;
    using System.IO;
    using System.Reflection;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.OpenApi.Models;
    using NKS.Payments.API.Interfaces;
    using NKS.Payments.API.Services;
    public static class Dependencies
    {
        /// <summary>
        /// Extension method to register dependencies local to project
        /// and out of startup class to leave it clean.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="config"></param>
        /// <returns>Service Collection Object</returns>
        public static IServiceCollection AddAPIConfiguration(this IServiceCollection services,IConfiguration config)
        {
            
            var swaggerConfig = config.GetSection("SwaggerConfiguration").Get<Swagger>();

            services.AddMvcCore();
                

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
            services.AddTransient<IPaymentService,PaymentService>();
            return services;
        }
    }
}
