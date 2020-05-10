using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Midterm_Project_Group_1_POS_Terminal_May_2020
{
    class CreditCardPayment : Payment
    {
        //properties
        public string CreditCardNumber { get; set; }

        public DateTime ExpirationDate { get; set; }

        public int CVV { get; set; }

        public string Visa { get; set; }

        public string MasterCard { get; set; }

        public string Discover { get; set; }

        public string AmericanExpress { get; set; }

        public CreditCardPayment()
        {

        }

        public CreditCardPayment(string visa, string masterCard, string discover, string americanExpress, string creditCardNumber, DateTime expirationDate, int cVV) : base(string creditCard)
        {
            Visa = visa;
            MasterCard = masterCard;
            Discover = discover;
            AmericanExpress = americanExpress;
            CreditCardNumber = creditCardNumber;
            ExpirationDate = expirationDate;
            CVV = cVV;
        }

        public static string PayWithCreditCard(string cardNumber)
        {
            if (Regex.Match(cardNumber, @"^4[0-9]{12}(?:[0-9]{3})?$").Success)
            {
                return CreditCardPayment.visa;
            }

            if (Regex.Match(cardNumber, @"^(?:5[1-5][0-9]{2}|222[1-9]|22[3-9][0-9]|2[3-6][0-9]{2}|27[01][0-9]|2720)[0-9]{12}$"))
            {
                return CreditCardPayment.masterCard;
            }

            if (Regex.Match(cardNumber, @"^3[47][0-9]{13}$"))
            {
                return CreditCardPayment.americanExpress;
            }

            if (Regex.Match(cardNumber, @"^6(?:011|5[0-9]{2})[0-9]{12}$"))
            {
                return CreditCardPayment.discover;
            }

            throw new Exception("Unknown card.");
        }
    }
}
