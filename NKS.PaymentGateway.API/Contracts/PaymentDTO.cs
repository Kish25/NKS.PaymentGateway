namespace NKS.Payments.API.Contracts
{
    using System;
    using Core;

    /// <summary>
    /// DTO object to return on get request to caller.
    /// </summary>
    public class PaymentDTO
    {
        public string   CardHolderName     { get; init; }
        public string   CardNumber         { get; init; } // should we return last 4 digit of card?
        public string   Expiry             { get; init; }
        public string   Currency           { get; init; }
        public double  Amount             { get; init; }
        public DateTime BankSubmissionDate { get; init; }
        public DateTime BankProcessDate    { get; init; }
        public string   Status             { get; init; }
        public string   Reference          { get; init; }

        // considering only basic properties, not other dates such settle date, approved date,
        // declined date/reason and so others that i am not aware of.

        // Folder Name Contracts : Could be any name, though its agreed as contract
        // on specific end point as input and output of API request.

    }
}
