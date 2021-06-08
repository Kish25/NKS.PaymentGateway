namespace NKS.Payments.Infrastructure.Configuration
{
    using APIs;
    using Core.Interfaces;
    using Microsoft.Extensions.DependencyInjection;
    using Repositories;

    /// <summary>
    /// Extension method to register dependencies local to project
    /// and out of startup class to leave it clean.
    /// </summary>
    /// <returns>Service Collection Object</returns>

    public static class Dependencies
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            return services
                   .AddTransient<IFakeResultProvider, FakeResultProvider>()
                   .AddTransient<IPaymentsApi, PaymentsApi>()
                   .AddTransient<ICalendar, Calendar>()
                   .AddTransient<IPaymentRepository, PaymentRepository>();
        }
    }
}
