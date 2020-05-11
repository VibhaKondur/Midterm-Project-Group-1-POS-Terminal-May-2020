using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace Midterm_Project_Group_1_POS_Terminal_May_2020
{
    class MainMenu
    {
       public static void NewMethod(string[] args)
        {
            //GetUserInt("What would you like to do next?", 1, 5);
            DisplayMenu();

        }


        public static int DisplayMenu()
        {
            string[] menuItems = new string[5] { "View Inventory", "Remove Item from Cart", "Review Cart", "Checkout", "Clear Cart" };
            Console.WriteLine();

            for (int i = 0; i < menuItems.Length; i++)
            {
                Console.WriteLine($"{i + 1}  {menuItems[i]}");
            }
            int selection = GetUserInt("", 1, menuItems.Length);
            return selection;

        }

        public static int GetUserInt(string prompt, int lowerBound, int upperBound)
        {

            int num;
            while (true)
            {
                Console.WriteLine(prompt);
                string input = Console.ReadLine();
                bool isInt = int.TryParse(input, out num);
                bool inBound = (num >= lowerBound && num <= upperBound);

                if (isInt)
                {
                    if (inBound)

                        return num;

                    else
                        Console.WriteLine($"Input out of bounds. A whole number between {lowerBound} and {upperBound} is required");
                }
                else
                    Console.WriteLine("I'm sorry, your input wasn't valid. Please try again.");
            }
        }

        //public static double DisplayTotal()
        //{
        //    double price = 
        //    int quantitiy =



        //    return price * quantitiy;
        //}









    }
}   
