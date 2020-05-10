using System;
using System.Collections.Generic;
using System.Text;

namespace Midterm_Project_Group_1_POS_Terminal_May_2020
{
    class Payment
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
        public static string SelectPaymentMethod()
        {
            Console.WriteLine("Which payment method would you like to use - Cash, Check, or Credit Card?");
            string input = Console.ReadLine();
            return input;
        }
    }
}
