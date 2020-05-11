using System;
using System.Collections.Generic;
using System.Text;

namespace Midterm_Project_Group_1_POS_Terminal_May_2020
{
    class CheckPayment : Payment
    {
<<<<<<< HEAD
        private static string check;

        //properties
=======
 
        //properties
        public string Name { get; set; }

>>>>>>> 437b34769c3fbced979dabce05eb2ab0f13e72b3
        public double CheckAmount { get; set; }

        public int CheckNumber { get; set; }

        //default constructor
        public CheckPayment()
        {

        }

        //overloaded constructor
<<<<<<< HEAD
        public CheckPayment(double checkAmount, int checkNumber)
        {
=======
        public CheckPayment(string name, double checkAmount, int checkNumber)
        {
            Name = name;
>>>>>>> 437b34769c3fbced979dabce05eb2ab0f13e72b3
            CheckAmount = checkAmount;
            CheckNumber = checkNumber;
        }

        //method to have user pay with check
        public virtual double PaywithCheck()
        {
<<<<<<< HEAD
=======
            Console.WriteLine($"Enter name on check: ");
            string name = Console.ReadLine();
            
>>>>>>> 437b34769c3fbced979dabce05eb2ab0f13e72b3
            Console.WriteLine($"Enter the amount owed:  ");
            double checkAmount = double.Parse(Console.ReadLine());

            Console.WriteLine($"What's the check number?");
            int checkNumber = int.Parse(Console.ReadLine());

            return checkNumber;
        }
    }
}
