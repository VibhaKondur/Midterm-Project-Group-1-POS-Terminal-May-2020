using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Midterm_Project_Group_1_POS_Terminal_May_2020
{
    class CheckPayment : Payment
    {

         //properties
        public string Name { get; set; }

        public double CheckAmount { get; set; }

        public int CheckNumber { get; set; }

        //default constructor
        public CheckPayment()
        {

        }

        //overloaded constructor

        public CheckPayment(string name, double checkAmount, int checkNumber)
        {
            Name = name;
            CheckAmount = checkAmount;
            CheckNumber = checkNumber;
        }

        //method to have user pay with check
        public void PayWithCheck(Cart cart)
        {

            Console.WriteLine($"Enter name on check: ");
            string name = Console.ReadLine();
            
            //Console.WriteLine($"Amount owed: {cart.Subtotal()}.");
            //double checkAmount = double.Parse(Console.ReadLine());

            Console.WriteLine($"Enter three-digit check number in the upper-right corner of the check.");
            int checkNumber = int.Parse(Console.ReadLine());
            if (Regex.Match(checkNumber.ToString(), @"^\d{3}$").Success)
            {
                Console.WriteLine("That's a valid check number.");
            }
            else
            {
                Console.WriteLine("That's not a valid check number.");
            }

            Console.WriteLine("The check cleared.");
            //return checkNumber;
        }
    }
}
