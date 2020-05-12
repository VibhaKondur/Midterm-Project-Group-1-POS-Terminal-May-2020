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


        public static string PaymentMethod { get; set; }
        //public static string CreditCard { get; set; }

        //public static string Check { get; set; }

        //public static string Cash { get; set; }


        //default constructor
        public Payment()
        {
        }
        //overloaded constructor
        public Payment(string paymentMethod, string creditCard, string check, string cash)
        {
            PaymentMethod = paymentMethod;
            CreditCard = creditCard;
            Check = check;
            Cash = cash;
        }
        //method asking user which payment method they would like to use
        //uses while loop and if statements to determine the process to calculate payment
        public static void PrintReceipt(Cart myCart)
        {
            myCart.GetReceipt();
            Console.WriteLine($"Sales Tax: {(myCart.Subtotal() * 0.06).ToString("C", CultureInfo.CurrentCulture)}");
            CalculateTotal(0.06, myCart).ToString("C", CultureInfo.CurrentCulture);
           
            //Console.WriteLine($"{PaymentMethod}, {Total}, {CashPayment. AmountTendered}, {ChangeReceived} ");

            //string[] paymentType = { "Check", "Cash", "Credit Card" };
            //Console.WriteLine($"{paymentType}");
            //Console.WriteLine($"{);
            //Console.WriteLine($"Payment Method: {);
        }
        public static double CalculateTotal(double taxRate, Cart myCart)
        {
            Console.WriteLine($"Tax rate: {taxRate.ToString("P", CultureInfo.InvariantCulture)}");
            double total = myCart.Subtotal() * (1 + taxRate);
            Console.WriteLine($"Total: {total.ToString("C", CultureInfo.CurrentCulture)}");
            //string cash = "";
            //string creditCard = "";
            //string check = "";
          
           // double amountTendered = double.Parse(Console.ReadLine());

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
                    double taxRate = .06;
                    Cashy.PayWithCash(myCart, taxRate);
                    ReceiptCash receipt = new ReceiptCash(Cashy, myCart);
                    Console.WriteLine("About to print receipt.");
                    receipt.PrintReceipt();
                    //ReceiptCash receipt = new ReceiptCash(Cashy);
                    //receipt.PrintReceipt(myCart);
                    break;
                }
                else if (input == "check")
                {
                    CheckPayment check = new CheckPayment();
                    check.PayWithCheck(myCart);
                    ReceiptCheck receipt = new ReceiptCheck(check, myCart);
                    receipt.PrintReceipt();
                    //return check;
                    break;
                }
                else
                {
                    CreditCardPayment card = new CreditCardPayment();
                    card.PayWithCreditCard(myCart);
                    ReceiptCreditCard receipt = new ReceiptCreditCard(card, myCart);
                    receipt.PrintReceipt();
                    //return card;
                    break;
                }
            }
        }


       //// public static void PrintPaymentMethod()
       // {
       //     Console.WriteLine(Payment.Cash);
            
       // }
        

    }
}
