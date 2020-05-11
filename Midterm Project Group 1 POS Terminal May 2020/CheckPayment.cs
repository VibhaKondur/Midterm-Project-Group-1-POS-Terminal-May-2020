using System;
using System.Collections.Generic;
using System.Text;

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
        public double PaywithCheck()
        {

            Console.WriteLine($"Enter name on check: ");
            string name = Console.ReadLine();
            
            Console.WriteLine($"Enter the amount owed:  ");
            double checkAmount = double.Parse(Console.ReadLine());

            Console.WriteLine($"What's the check number?");
            int checkNumber = int.Parse(Console.ReadLine());

            return checkNumber;
        }
    }
}
