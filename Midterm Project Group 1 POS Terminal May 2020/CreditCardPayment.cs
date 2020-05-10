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

        //default constructor
        public CreditCardPayment()
        {

        }


        //overloaded constructor
        public CreditCardPayment(string creditCard, string visa, string masterCard, string discover, string americanExpress, string creditCardNumber, DateTime expirationDate, int cVV)
        {
            CreditCard = creditCard;
            Visa = visa;
            MasterCard = masterCard;
            Discover = discover;
            AmericanExpress = americanExpress;
            CreditCardNumber = creditCardNumber;
            ExpirationDate = expirationDate;
            CVV = cVV;
        }

        //method asking the user to enter their credit card info to pay
        public static bool PayWithCreditCard()

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
                Console.WriteLine($"Enter name listed on Credit Card:  ");
                string name = Console.ReadLine();

                Console.WriteLine($"Enter credit card number:  ");
                string creditCardNumber = Console.ReadLine();

                Console.WriteLine($"Enter expiration date in format MM/YYYY:   ");
                DateTime expirationDate = DateTime.Parse(Console.ReadLine());

                try
                {
                    if (expirationDate != "MM/YYYY")
                    {
                        throw new FormatException("Invalid Input. Please input date as format MM/YYYY");
                    }
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }

                Console.WriteLine($"Enter 3 digit code (CVV) on back of card :   ");
                int cVV = int.Parse(Console.ReadLine());
                cVV = 0;

                try
                {
                    if (cVV != 123)
                    {
                        throw new FormatException("Invalid CVV. Please input correct CVV");
                    }
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }

                Payment.Add(name, creditCardNumber, expirationDate, cVV);

            }

        //method - using regex - validating type of credit card used for purchase - Visa, MasterCard, Amex, and Discover 
        public virtual bool DetermineCreditCardType(string creditCardNumber)
        {
            if (Regex.IsMatch(creditCardNumber, @"^4[0-9]{12}(?:[0-9]{3})?$"))
            {
                return CreditCardPayment.visa;
            }

            if (Regex.IsMatch(creditCardNumber, @"^(?:5[1-5][0-9]{2}|222[1-9]|22[3-9][0-9]|2[3-6][0-9]{2}|27[01][0-9]|2720)[0-9]{12}$"))
            {
                return CreditCardPayment.masterCard;
            }

            if (Regex.IsMatch(creditCardNumber, @"^3[47][0-9]{13}$"))
            {
                return CreditCardPayment.americanExpress;
            }

            if (Regex.IsMatch(creditCardNumber, @"^6(?:011|5[0-9]{2})[0-9]{12}$"))
            {
                return CreditCardPayment.discover;
            }

            throw new Exception("Unknown card.");
        }

        //method to validate CVV (security code)
        public bool IsValidSecurityCode(int cVV)
        {
            bool isValid = Regex.IsMatch(cVV, @"^\d{3}$").Success;
            return isValid;
        }//end IsValidSecurityCode()

        //method to validate expiration date
        public bool IsValidExpiration(DateTime expirationDate)
        {
            string[] date = Regex.Split(expirationDate, "/");
            string[] currentDate = Regex.Split(DateTime.Now.ToString("MM/yyyy"), "/");
            int compareYears = string.Compare(date[1], currentDate[1]);
            int compareMonths = string.Compare(date[0], currentDate[0]);

            //if expiration date is in MM/YYYY format
            if (Regex.Match(expirationDate, @"^\d{2}/\d{4}$"))
            {
                //if month is "01-12" and year starts with "20"
                if (Regex.Match(date[0], @"^[0][1-9]|[1][0-2]$").Success)
                {
                    //if expiration date is after current date
                    if ((compareYears == 1) || (compareYears == 0 && (compareMonths == 1)))
                    {
                        return true;
                    }
                }
            }
            return false;
        }//end IsValidExpiration

           
    }

}
}
