//https://fullstackmark.com/post/20/painless-integration-testing-with-aspnet-core-web-api
namespace NKS.PatmentGateway.IntegrationTests
{
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc.Testing;
    using Microsoft.Extensions.DependencyInjection;
    using Payments.API;
    using Payments.API.Interfaces;

    public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<Startup>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder
                .ConfigureServices(services =>
              {
                  // Create a new service provider.
                  var serviceProvider = new ServiceCollection();
                 
                  serviceProvider.BuildServiceProvider();

              });
        }
    }
}
