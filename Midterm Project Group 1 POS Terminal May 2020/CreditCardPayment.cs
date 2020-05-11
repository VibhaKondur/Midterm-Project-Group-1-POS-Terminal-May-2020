using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Midterm_Project_Group_1_POS_Terminal_May_2020
{
    class CreditCardPayment : Payment
    {
        //properties
<<<<<<< HEAD
        public string CreditCardNumber { get; set; }

        public DateTime ExpirationDate { get; set; }

        public int CVV { get; set; }

        public string Visa { get; set; }

        public string MasterCard { get; set; }

        public string Discover { get; set; }

        public string AmericanExpress { get; set; }
=======
        public string Name { get; set;  }

        public string CreditCardNumber { get; set; }

        public string ExpirationDate { get; set; }

        public int CVV { get; set; }

        public string Brand { get; set; }

        //public string Visa { get; set; }

        //public string MasterCard { get; set; }

        //public string Discover { get; set; }

        //public string AmericanExpress { get; set; }
>>>>>>> 437b34769c3fbced979dabce05eb2ab0f13e72b3

        //default constructor
        public CreditCardPayment()
        {

        }


        //overloaded constructor
<<<<<<< HEAD
        public CreditCardPayment(string creditCard, string visa, string masterCard, string discover, string americanExpress, string creditCardNumber, DateTime expirationDate, int cVV)
        {
            CreditCard = creditCard;
            Visa = visa;
            MasterCard = masterCard;
            Discover = discover;
            AmericanExpress = americanExpress;
=======
        public CreditCardPayment(string name, string creditCard, string brand, string creditCardNumber, string expirationDate, int cVV)
        {
            Name = name;
            CreditCard = creditCard;
            Brand = brand;
            //Visa = visa;
            //MasterCard = masterCard;
            //Discover = discover;
            //AmericanExpress = americanExpress;
>>>>>>> 437b34769c3fbced979dabce05eb2ab0f13e72b3
            CreditCardNumber = creditCardNumber;
            ExpirationDate = expirationDate;
            CVV = cVV;
        }

<<<<<<< HEAD

        //method asking the user to enter their credit card info to pay
=======
        //method asking the user to enter their credit card info to pay
        //public static bool PayWithCreditCard()

        //public CreditCardPayment(string visa, string masterCard, string discover, string americanExpress, string creditCardNumber, DateTime expirationDate, int cVV) : base(string creditCard)
        //{
        //    Visa = visa;
        //    MasterCard = masterCard;
        //    Discover = discover;
        //    AmericanExpress = americanExpress;
        //    CreditCardNumber = creditCardNumber;
        //    ExpirationDate = expirationDate;
        //    CVV = cVV;
        //}


>>>>>>> 437b34769c3fbced979dabce05eb2ab0f13e72b3
        public static string PayWithCreditCard(string cardNumber)

        {
            Console.WriteLine($"Enter name listed on Credit Card:  ");
            string name = Console.ReadLine();

            Console.WriteLine($"Enter credit card number:  ");
            string creditCardNumber = Console.ReadLine();

<<<<<<< HEAD
            Console.WriteLine($"Enter expiration date in format MM/YYYY:   ");
            DateTime expirationDate = DateTime.Parse(Console.ReadLine());

            try
            {
                if (expirationDate != "MM/YYYY")
                {
                    throw new FormatException("Invalid Input. Please input date as format MM/YYYY");
=======
            Console.WriteLine($"Enter expiration date in format MM/YY:   ");
            
                //DateTime expirationDate = DateTime.Parse(Console.ReadLine());
            string expirationDate = Console.ReadLine();
            try
            {
                if (expirationDate != "MM/YY")
                {
                    throw new FormatException("Invalid Input. Please input date as format MM/YY");
>>>>>>> 437b34769c3fbced979dabce05eb2ab0f13e72b3
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

<<<<<<< HEAD
            Payment.Add(name, creditCardNumber, expirationDate, cVV);
=======
            string creditCardResult = name + creditCardNumber + expirationDate.ToString() + cVV;
            return creditCardResult;
            //Payment.Add(name, creditCardNumber, expirationDate, cVV);
>>>>>>> 437b34769c3fbced979dabce05eb2ab0f13e72b3

        }

        //method - using regex - validating type of credit card used for purchase - Visa, MasterCard, Amex, and Discover
<<<<<<< HEAD
        public virtual bool DetermineCreditCardType(string creditCardNumber)
        {
            if (Regex.IsMatch(creditCardNumber, @"^4[0-9]{12}(?:[0-9]{3})?$"))
            {
                return CreditCardPayment.visa;
=======
        public virtual void DetermineCreditCardType(string creditCardNumber)
        {
            if (Regex.IsMatch(creditCardNumber, @"^4[0-9]{12}(?:[0-9]{3})?$"))
            {
                Brand = "visa";
>>>>>>> 437b34769c3fbced979dabce05eb2ab0f13e72b3
            }

            if (Regex.IsMatch(creditCardNumber, @"^(?:5[1-5][0-9]{2}|222[1-9]|22[3-9][0-9]|2[3-6][0-9]{2}|27[01][0-9]|2720)[0-9]{12}$"))
            {
<<<<<<< HEAD
                return CreditCardPayment.masterCard;
=======
                Brand = "master card";
>>>>>>> 437b34769c3fbced979dabce05eb2ab0f13e72b3
            }

            if (Regex.IsMatch(creditCardNumber, @"^3[47][0-9]{13}$"))
            {
<<<<<<< HEAD
                return CreditCardPayment.americanExpress;
=======
                Brand = "discover";
>>>>>>> 437b34769c3fbced979dabce05eb2ab0f13e72b3
            }

            if (Regex.IsMatch(creditCardNumber, @"^6(?:011|5[0-9]{2})[0-9]{12}$"))
            {
<<<<<<< HEAD
                return CreditCardPayment.discover;
=======
                Brand = "american express";
>>>>>>> 437b34769c3fbced979dabce05eb2ab0f13e72b3
            }

            throw new Exception("Unknown card.");
        }

        //method to validate CVV (security code)
        public bool IsValidSecurityCode(int cVV)
        {
<<<<<<< HEAD
            bool isValid = Regex.Match(cVV, @"^\d{3}$").Success;
            return isValid;
        }

        //method to validate expiration date
        public bool IsValidExpiration(DateTime expirationDate)
        {
            string[] date = Regex.Split(expirationDate, "/");
            string[] currentDate = Regex.Split(DateTime.Now.ToString("MM/yyyy"), "/");
            int compareYears = string.Compare(date[1], currentDate[1]);
            int compareMonths = string.Compare(date[0], currentDate[0]);

            //if expiration date is in MM/YYYY format
            if (Regex.IsMatch(expirationDate, "@"^\d{2}/\d{4}$"))
=======
            bool isValid = Regex.Match(cVV.ToString(), @"^\d{3}$").Success;
            return isValid;
        }//end IsValidSecurityCode()

       // method to validate expiration date
        public bool IsValidExpiration(string expirationDate)
        {
            string[] date = Regex.Split(expirationDate, "/");
            string[] currentDate = Regex.Split(DateTime.Now.ToString("MM/yy"), "/");
            int compareYears = string.Compare(date[1], currentDate[1]);
            int compareMonths = string.Compare(date[0], currentDate[0]);

            //if expiration date is in MM/YY format
            if (Regex.Match(expirationDate, @"^(0[1-9]|1[012])[/]\d{2}$").Success)
>>>>>>> 437b34769c3fbced979dabce05eb2ab0f13e72b3
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
<<<<<<< HEAD
        }
=======
        }//end IsValidExpiration
>>>>>>> 437b34769c3fbced979dabce05eb2ab0f13e72b3


    }

}
<<<<<<< HEAD
}
=======

>>>>>>> 437b34769c3fbced979dabce05eb2ab0f13e72b3
