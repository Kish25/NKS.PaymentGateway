namespace NKS.Payments.API.Contracts
{
    using System;

    /// <summary>
    /// Response after processing payment request
    /// Status is either Success or Fail and reference for internal storage of payment.
    ///
    /// there could be various status - begin with two.
    /// </summary>
    public class PaymentProcessResponse
    {
        public Guid GatewayReference { get; set; }
        public string Status { get; set; }
    }
}
