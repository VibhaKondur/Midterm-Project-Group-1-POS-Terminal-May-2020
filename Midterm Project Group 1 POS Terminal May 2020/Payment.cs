using System;
using System.Collections.Generic;
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
        public static Payment SelectPaymentMethod()
        {
            Console.WriteLine("Which payment method will you be using today - Cash, Check, or Credit Card?");
            string input = Console.ReadLine().ToLower();

            while (input != "cash" && input != "credit card" && input != "check")
            {
                Console.WriteLine("Invalid input. Which payment method would you like to use - Cash, Check, or Credit Card?");
                input = Console.ReadLine();
            }

            if (input == "cash")
            {
                CashPayment Cashy = new CashPayment();
                return Cashy;
            }
            else if (input == "Check")
            {
                CheckPayment check = new CheckPayment();
                return check;
            }
            else
            {
                CreditCardPayment card = new CreditCardPayment();
                return card;
            }
        }
    }
}
