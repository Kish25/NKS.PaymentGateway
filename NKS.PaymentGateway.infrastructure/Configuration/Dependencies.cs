namespace NKS.Payments.Infrastructure.Configuration
{
    using Microsoft.Extensions.DependencyInjection;
    using Core.Interfaces;
    using Repositories;

    /// <summary>
    /// Extension method to register dependencies local to project
    /// and out of startup class to leave it clean.
    /// </summary>
    /// <param name="services"></param>
    /// <returns>Service Collection Object</returns>

    public static class Dependencies
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            return services.AddTransient<IPaymentRepository,PaymentRepository>();
        }
    }
}
