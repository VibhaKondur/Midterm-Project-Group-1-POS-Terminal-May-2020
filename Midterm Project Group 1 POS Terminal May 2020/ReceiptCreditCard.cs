using System;
using System.Globalization;

namespace Midterm_Project_Group_1_POS_Terminal_May_2020
{
    //PROPERTIES
    class ReceiptCreditCard : Receipt
    {
        CreditCardPayment CreditCardPayment;
    
        //OVERLOAD CONSTRUCTOR
        public ReceiptCreditCard(CreditCardPayment creditCardPayment, Cart cart)
        {
            Cart = cart;
            CreditCardPayment = creditCardPayment;
        }
        //DEFAULT CONSTRUCTOR
        public ReceiptCreditCard() : base() { }
        //METHODS
        public override void PrintReceipt()
        {
            base.PrintReceipt();
            string name = $"Name: {CreditCardPayment.Name}";
            string brand = $"Brand: {CreditCardPayment.Brand}";
            string creditCardNumber = $"Check Number: {CreditCardPayment.CreditCardNumber}";
            string redactedCreditCardNumber;
            redactedCreditCardNumber = "Credit Card Number: **** **** **** " + creditCardNumber.Substring(26);

            Console.WriteLine(name + "\n" + brand + "\n" + redactedCreditCardNumber);
        }
    }
}
