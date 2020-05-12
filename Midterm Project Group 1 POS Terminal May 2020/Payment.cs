using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
namespace Midterm_Project_Group_1_POS_Terminal_May_2020
{
    abstract class Payment
    {
        //properties
        public string CreditCard { get; set; }
        public string Check { get; set; }
        public string Cash { get; set; }
        //default constructor
        public Payment()
        {
        }
        //overloaded constructor
        public Payment(string creditCard, string check, string cash)
        {
            CreditCard = creditCard;
            Check = check;
            Cash = cash;
        }
        //method asking user which payment method they would like to use
        //uses while loop and if statements to determine the process to calculate payment
        public static void PrintReceipt(Cart myCart)
        {
            myCart.GetReceipt();
            Console.WriteLine($"Sales Tax: {(myCart.Subtotal() * 1.06).ToString("P", CultureInfo.InvariantCulture)}");
            CalculateTotal(0.06, myCart).ToString("C", CultureInfo.CurrentCulture);
        }
        public static double CalculateTotal(double taxRate, Cart myCart)
        {
            Console.WriteLine($"Tax rate: {taxRate.ToString("P", CultureInfo.InvariantCulture)}");
            double total = myCart.Subtotal() * (1 + taxRate);
            Console.WriteLine($"Total: {total.ToString("C", CultureInfo.CurrentCulture)}");
            return total;
        }
        public static void SelectPaymentMethod(Cart myCart)
        {
            Console.WriteLine("\nWhich payment method will you be using today - Cash, Check, or Credit Card?");
            string input = Console.ReadLine().ToLower();
            while (true)
            {
                if (input != "cash" && input != "credit card" && input != "check")
                {
                    Console.WriteLine("Invalid input. Which payment method would you like to use - Cash, Check, or Credit Card?");
                    //input = Console.ReadLine();
                }
                if (input == "cash")
                {
                    CashPayment Cashy = new CashPayment();
                    Cashy.PayWithCash(myCart);
                    break;
                }
                else if (input == "check")
                {
                    CheckPayment check = new CheckPayment();
                    check.PaywithCheck(myCart);
                    //return check;
                    break;
                }
                else
                {
                    CreditCardPayment card = new CreditCardPayment();
                    card.PayWithCreditCard(myCart);
                    //return card;
                    break;
                }
            }
        }
    }
}
