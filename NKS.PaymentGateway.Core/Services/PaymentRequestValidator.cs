namespace NKS.Payments.Core.Services
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;
    using Entities;
    using Interfaces;

    public class PaymentRequestValidator : IPaymentRequestValidator
    {
        public bool Validate(PaymentRequest payment)
        {
            if (payment.Amount == 0 ||
                (string.IsNullOrEmpty(payment.Currency) ||
                 string.IsNullOrWhiteSpace(payment.Currency)))
                return false;

            if (string.IsNullOrEmpty(payment.CardDetails.CardHolderName) ||
                string.IsNullOrWhiteSpace(payment.CardDetails.CardHolderName))
                return false;

            var cardNumber = payment.CardDetails.CardNumber;

            if (string.IsNullOrEmpty(cardNumber) || string.IsNullOrWhiteSpace(cardNumber))
                return false;
            //throw new InvalidCardNumberException();

            var strippedCharacters = Regex.Replace(cardNumber, @"[^\d]", "");

            if (strippedCharacters.Length < 13)
                return false;
            //throw new CardNumberIsTooShortException();

            if (!cardNumber.All(char.IsDigit))
                return false;
            //throw new CardNumberContainsCharactersException();

            if ((payment.CardDetails.ExpiryMonth < DateTime.Now.Month
             && payment.CardDetails.ExpiryYear <= DateTime.Now.Year)
                || payment.CardDetails.ExpiryYear < DateTime.Now.Year
                )
                return false;
            //throw new CardExpiredException();

            if (payment.CardDetails.Cvv < 99) // at least 3 numbers
                return false;
            return true;
        }
    }
}