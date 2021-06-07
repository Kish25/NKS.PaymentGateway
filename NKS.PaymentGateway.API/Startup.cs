namespace NKS.Payments.API
{
    using Amazon.DynamoDBv2;
    using Amazon.S3;
    using Configuration;
    using Core.Entities;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using NKS.Payments.Infrastructure.Configuration;
    using Serilog;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            Log.Information("Configuring services.");
            services.Configure<AWSConfiguration>(Configuration.GetSection("AWSConfiguration"));
            services.Configure<CheckoutBankAPISetting>(Configuration.GetSection(nameof(CheckoutBankAPISetting)));

            Configuration.GetAWSOptions();

            services.AddControllers();
            services.AddApiConfiguration(Configuration);
            services.AddInfrastructure();
            //services.AddDefaultAWSOptions();
            services.AddAWSService<IAmazonS3>();
            services.AddAWSService<IAmazonDynamoDB>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var swaggerConfig = Configuration.GetSection("SwaggerConfiguration").Get<Swagger>();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "NKS.Payments.API v1"));
            }
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint($"/swagger/v{swaggerConfig.Version}/swagger.json", "API v1"));

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
