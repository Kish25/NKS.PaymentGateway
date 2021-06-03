using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using NKS.PaymentGateway.Core.Interfaces;
using NKS.PaymentGateway.infrastructure.Repositories;

namespace NKS.PaymentGateway.infrastructure.Configuration
{
    public static class Dependencies
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            return services.AddTransient<IPaymentRepository,PaymentRepository>();
        }
    }
}
