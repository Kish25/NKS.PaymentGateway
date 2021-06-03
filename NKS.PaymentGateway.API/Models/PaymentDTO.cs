using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NKS.PaymentGateway.Core.Entities;

namespace NKS.PaymentGateway.API.Models
{
    public class PaymentDTO
    {
        public PaymentDTO FromPayment(Payment payment)
        {
            // respose of get request.
            return new PaymentDTO();

        }
    }
}
