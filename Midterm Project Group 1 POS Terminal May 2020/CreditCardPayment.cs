using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
namespace Midterm_Project_Group_1_POS_Terminal_May_2020
{
    class CreditCardPayment : Payment
    {
        //properties
        public string Name { get; set; }
        public string Brand { get; set; }
        public string CreditCardNumber { get; set; }
        public string ExpirationDate { get; set; }
        public int CVV { get; set; }
        //default constructor
        public CreditCardPayment()
        {
        }
        //overloaded constructor
        public CreditCardPayment(string name, string brand, string creditCardNumber, string expirationDate, int cVV)
        {
            Name = name;
            Brand = brand;
            CreditCardNumber = creditCardNumber;
            ExpirationDate = expirationDate;
            CVV = cVV;
        }
        //method asking the user to enter their credit card info to pay
        public string PayWithCreditCard(Cart myCart)
        {
            bool Valid = true;
            bool askAgain = true;
            string name = "";
            string creditCardNumber = "";
            string expirationDate = "";
            int cVV = 0;
            while (askAgain)
            {
                Console.WriteLine($"Enter first and last name listed on Credit Card:  ");
                name = Console.ReadLine().ToLower();
                if (Regex.Match(name, @"^([a-z.,\- ]+){2,4}$").Success)
                {
                    Name = name;
                    askAgain = false;
                }
                else
                {
                    Console.WriteLine($"Invalid entry. Please input form first name last name on Credit Card. ");
                    askAgain = true;
                }
            }
            askAgain = true;
            while (askAgain)
            {
                Console.WriteLine($"Enter credit card number:  ");
                creditCardNumber = Console.ReadLine();
                if (DetermineCreditCardType(creditCardNumber))
                {
                    CreditCardNumber = creditCardNumber;
                    askAgain = false;
                }
                else
                {
                    Console.WriteLine($"Invalid entry. Please enter valid credit card number. ");
                    askAgain = true;
                }
            }
            askAgain = true;
            while (askAgain)
            {
                Console.WriteLine($"Enter expiration date in format MM/YY:  ");
                expirationDate = Console.ReadLine();
                if (IsValidExpiration(expirationDate))
                {
                    askAgain = false;
                }
                else
                {
                    Console.WriteLine("$Invalid entry. Please enter expiration date in format MM/YY. ");
                    askAgain = true;
                }
            }
            askAgain = true;
            while (askAgain)
            {
                Console.WriteLine($"Enter three digit code (CVV) located on the back of the card:  ");
                cVV = int.Parse(Console.ReadLine());
                if (IsValidSecurityCode(cVV))
                {
                    askAgain = false;
                }
                else
                {
                    Console.WriteLine("$Invalid entry. Please enter valid CVV.");
                    askAgain = true;
                }
            }
            string creditCardResult = name + creditCardNumber + expirationDate.ToString() + cVV;
            return creditCardResult;
            //while (true)
            //{
            //    Console.WriteLine($"Enter first and last name listed on Credit Card:  ");
            //    string name = Console.ReadLine().ToLower();
            //    if (!Regex.Match(name, @"/^[a-z ,.'-]{2,}$/gi").Success)
            //    {
            //        //return name;
            //        Console.WriteLine("Invalid input. Please enter format first name last name as seen on credit card.");
            //    }
            //    Console.WriteLine($"Enter credit card number:  ");
            //    string creditCardNumber = Console.ReadLine();
            //    if (DetermineCreditCardType(creditCardNumber))
            //    {
            //        Console.WriteLine("Invalid credit card number. Please put in a valid credit card number.");
            //        return creditCardNumber;
            //    }
            //    Console.WriteLine($"Enter expiration date in format MM/YY:   ");
            //    string expirationDate = Console.ReadLine();
            //    if (!IsValidExpiration(expirationDate))
            //    {
            //        Console.WriteLine("Invalid expiration date. Please put in a valid expiration date.");
            //        return expirationDate;
            //    }
            //    Console.WriteLine($"Enter 3 digit code (CVV) listed on back of card :   ");
            //    int cVV = int.Parse(Console.ReadLine());
            //    if (IsValidSecurityCode(cVV))
            //    {
            //        Console.WriteLine("Invalid CVV. Please put in a valid CVV.");
            //        return cVV.ToString();
            //        //throw new FormatException("Invalid CVV. Please input correct CVV");
            //    }
        }
        //method - using regex - validating type of credit card used for purchase - Visa, MasterCard, Amex, and Discover
        public virtual bool DetermineCreditCardType(string creditCardNumber)
        {
            if (Regex.IsMatch(creditCardNumber, @"^3[47][0-9]{13}$"))
            {
                Brand = "American Express";
                return true;
            }
            if (Regex.IsMatch(creditCardNumber, @"^(?:5[1-5][0-9]{2}|222[1-9]|22[3-9][0-9]|2[3-6][0-9]{2}|27[01][0-9]|2720)[0-9]{12}$"))
            {
                Brand = "Mastercard";
                return true;
            }
            if (Regex.IsMatch(creditCardNumber, @"^4[0-9]{12}(?:[0-9]{3})?$"))
            {
                Brand = "Visa";
                return true;
            }
            if (Regex.IsMatch(creditCardNumber, @"^6(?:011|5[0-9]{2})[0-9]{12}$"))
            {
                Brand = "Discover";
                return true;
            }
            return false;
        }
        //method to validate CVV (security code)
        public bool IsValidSecurityCode(int cVV)
        {
            bool isValid = Regex.Match(cVV.ToString(), @"^\d{3}$").Success;
            return isValid;
        }
        // method to validate expiration date
        public bool IsValidExpiration(string expirationDate)
        {
            string[] date = Regex.Split(expirationDate, "/");
            string[] currentDate = Regex.Split(DateTime.Now.ToString("MM/yy"), "/");
            int compareYears = string.Compare(date[1], currentDate[1]);
            int compareMonths = string.Compare(date[0], currentDate[0]);
            //if expiration date is in MM/YY format
            if (Regex.Match(expirationDate, @"^(0[1-9]|1[012])[/]\d{2}$").Success)
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
        }
    }//end IsValidExpiration
}