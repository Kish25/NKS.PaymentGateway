namespace NKS.Payments.API.Contracts
{
    using System;
    /// <summary>
    /// DTO object to return on get request to caller.
    /// </summary>
    public class PaymentDTO
    {
        public string CardHolderName { get; set; }
        public string CardNumber { get; set; }  // last 4 digit of card
        public string Expiry { get; set; }
        public string Currency { get; set; }
        public decimal Amount { get; set; }
        public DateTime BankSubmissionDate { get; set; }
        public DateTime BankProcessDate { get; set; }

        
        // considering only basic properties, not other dates such settle date, approved date,
        // declined date/reason and so others that i am not aware of.

        // Folder Name Contracts : Could be any name, though its agreed as contract
        // on specific end point as input and output of API request.
        
    }
}
