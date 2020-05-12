using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Midterm_Project_Group_1_POS_Terminal_May_2020
{
    class Product
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public int Inventory { get; set; }
        public double Price { get; set; }
        //Default Constructor
        public Product() { }
        //Constructor
        public Product(string _name, string _category, string _description, int _inventory, double _price)
        {
            Name = _name;
            Category = _category;
            Description = _description;
            Inventory = _inventory;
            Price = _price;
        }

        public static List<Product> AddToInventory(List<Product> inventory)
        {
            Console.Clear();
            bool keepRun = GetYesOrNo("Would you like to add a new item into inventory? y/n: ");
            while(keepRun)
            {
                string newName = GetUserString("Please enter the NAME of the product: ");
                string newDesc = GetUserString("Please enter the new product's DESCRIPTION: ");
                string newCat = GetUserString("Please enter the new product's DEPARTMENT CATEGORY: ");
                double newPrice = GetUserDouble("Please enter the new product's UNIT PRICE: ");
                int newInv = GetUserInt("Please enter the QUANTITY of new product to add to INVENTORY: ");
                Console.Clear();
                Console.WriteLine("Please review the inventory item to add:");
                Console.WriteLine($"{newName}\t{newDesc}");
                Console.WriteLine($"Department: {newCat}\tPrice: {newPrice:C}\tQuantity:{newInv}");
                if(GetYesOrNo($"Add {newInv} {newName} into inventory? y/n"))
                {
                    inventory.Add(new Product(newName, newCat, newDesc, newInv, newPrice));
                }
                else
                {
                    return inventory;
                }
                keepRun = GetYesOrNo("Would you like to add another item?");
            }

            FileIO write = new FileIO();
            write.WriteToInventory(inventory);
            return inventory;
        }

        public static bool GetYesOrNo(string prompt)
        {
            //Prompts user for y/n; returns true for y and false for n
            while (true)
            {
                Console.WriteLine(prompt);
                string input = Console.ReadLine().ToLower();

                if (input == "y")
                {
                    return true;
                }
                else if (input == "n")
                {
                    return false;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input. " + prompt);
                    Console.ResetColor();
                }

            }
        }

        public static string GetUserString(string prompt)
        {   //asks user for input with prompt string
            //validates against empty string
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine(prompt);
                string userInput = Console.ReadLine();

                if (String.IsNullOrWhiteSpace(userInput))
                {
                    Console.WriteLine();
                    Console.WriteLine("I'm sorry, input cannot be empty.");
                }
                else
                {
                    return userInput;
                }
            }
        }

        public static int GetUserInt(string prompt)
        {
            //Prompts user for an int, validates, returns
            int num;
            while (true)
            {
                Console.WriteLine(prompt);
                string input = Console.ReadLine();
                bool isInt = int.TryParse(input, out num);

                if (isInt)
                    return num;
                else
                    Console.WriteLine("I'm sorry, your input wasn't valid. Please try again.");

            }
        }
        public static double GetUserDouble(string prompt)
        {
            //Prompts user for an int, validates, returns
            double num;
            while (true)
            {
                Console.WriteLine(prompt);
                string input = Console.ReadLine();
                bool isDub = double.TryParse(input, out num);

                if (isDub)
                    return num;
                else
                    Console.WriteLine("I'm sorry, your input wasn't valid. Please try again.");

            }
        }


    }
}
