﻿namespace NKS.Payments.API.Configuration
{
    using Core.Interfaces;
    using Core.Services;
    using Interfaces;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.OpenApi.Models;
    using Services;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Reflection;
    public static class Dependencies
    {
        /// <summary>
        /// Register dependencies local to project
        /// </summary>
        /// <param name="services"></param>
        /// <param name="config"></param>
        /// <returns>Service Collection Object</returns>
        public static IServiceCollection AddApiConfiguration(this IServiceCollection services, IConfiguration config)
        {
            var swaggerConfig = config.GetSection("SwaggerConfiguration").Get<Swagger>();

            services.AddMvcCore();
            services.AddTransient<IPaymentMapper, PaymentMapper>()
                    .AddTransient<IPaymentRequestValidator, PaymentRequestValidator>()
                    .AddTransient<IPaymentRequestValidator, PaymentRequestValidator>()
                    .AddTransient<IPaymentService, PaymentService>()
                    .AddScoped<IUserService, UserService>();

            services.AddHttpClient<IPaymentsAPI>();

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
                options.AddSecurityDefinition("basic", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Description = "Basic Authorization header using the Bearer scheme.",
                    Type = SecuritySchemeType.Http,
                    Scheme = "basic",
                    In = ParameterLocation.Header
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                    new OpenApiSecurityScheme()
                    { 
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "basic"
                        }

                    },new List<string>()
                    }
                });
            });


            return services;
        }
    }
}
