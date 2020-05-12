using System;
using System.ComponentModel;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Threading;

namespace Midterm_Project_Group_1_POS_Terminal_May_2020
{
    //CLASS DECLARATION
    class ProductView
    {
        //PROPERTIES
        public Product DisplayProduct { get; set; }
        //CONSTRUCTOR
        public ProductView(Product displayProduct)
        {
            DisplayProduct = displayProduct;
        }
        //DEFAULT CONSTRUCTOR
        public ProductView() { }
        //CLASS METHODS
        public void Display()
        {
            //PRINT OUT ALL THE PROPERTIES AND VALUES OF PRODUCT
            Console.WriteLine("");
            foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(DisplayProduct))
            {
                string propertyDescriptor = descriptor.Name;
                object value = descriptor.GetValue(DisplayProduct);
                string propertyValue;
                if (value.ToString().Length <= 50)
                {
                    if (propertyDescriptor == "Price")
                    {
                        double price = double.Parse(value.ToString());
                        propertyValue = price.ToString("C", CultureInfo.CurrentCulture);
                    }
                    else
                    {
                        propertyValue = value.ToString();
                    }
                    //INDENTATION
                    string column1 = propertyDescriptor + ": ";
                    string column2 = propertyValue;
                    //COLUMN 1
                    Console.Write(column1);
                    //COLUMN 2
                    Console.WriteLine((column2.PadLeft(30 - column1.Length)));
                }
            }
            foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(DisplayProduct))
            {
                string propertyDescriptor = descriptor.Name;
                object value = descriptor.GetValue(DisplayProduct);
                string propertyValue;
                if (value.ToString().Length > 25)
                {
                    propertyValue = value.ToString();
                    //INDENTATION
                    string column1 = propertyDescriptor + ": ";
                    string column2 = propertyValue;
                    //COLUMN 1
                    Console.Write(column1);
                    //COLUMN 2
                    Console.WriteLine((column2.PadLeft(30 - column1.Length)));
                }
            }
            Console.WriteLine("");
        }

        public bool Verify(out int quantity)
        {
            if (AskYesOrNo($"Would you like to add {DisplayProduct.Name}? (y/n)"))
            {
                Console.WriteLine($"\nHow many {DisplayProduct.Name} would you like to add?");
                bool valid = false;
                while (!valid)
                {
                    string selectionSummary;
                    if (int.TryParse(Console.ReadLine().Trim(), out int response))
                    {
                        if (response > 0 && response <= DisplayProduct.Inventory)
                        {
                            quantity = response;
                            selectionSummary = ($"\nAre you sure you want to add {quantity} units of {DisplayProduct.Name} to the cart for {(quantity * DisplayProduct.Price).ToString("C", CultureInfo.CurrentCulture)}?");
                            if (AskYesOrNo(selectionSummary))
                            {
                                valid = true;
                                return true;
                            }
                            else
                            {
                                valid = true;
                                return false;
                            }
                        }
                        else if (response > DisplayProduct.Inventory)
                        {
                            Console.WriteLine($"{DisplayProduct.Inventory} units of {DisplayProduct.Name} are available. Choose a quantity between 0 and {DisplayProduct.Inventory}");
                            valid = false;
                        }
                        else if (response <= 0)
                        {
                            quantity = 0;
                            return false;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Your response must be a whole number.");
                        valid = false;
                    }
                }
            }
            quantity = 0;
            return false;
        }
        public Box BoxUpProduct(int quantity)
        {
            Box boxToCart = new Box(DisplayProduct, quantity);
            Console.WriteLine($"{quantity} units of {DisplayProduct.Name} added to box.");
            return boxToCart;
        }

        public void OfferToAddToCart(Cart theCart)
        {
            if (Verify(out int quantity))
            {
                Console.WriteLine($"{quantity} units of {DisplayProduct.Name} added to cart.");
            }
        }
        public static bool AskYesOrNo(string question)
        {
            bool loop = true;
            int counter = 0;
            while (loop && counter < 3)
            {
                Console.WriteLine(question);
                string response = Console.ReadLine().ToLower();
                Regex yesTrue = new Regex(@"\b(y(es)?)\b");
                Regex noFalse = new Regex(@"\b(n(o)?)\b");
                try
                {
                    if (yesTrue.IsMatch(response))
                    {
                        loop = false;
                        return true;
                    }
                    else if (noFalse.IsMatch(response))
                    {
                        loop = false;
                        return false;
                    }
                    else
                    {
                        if (counter < 2)
                        {
                        Console.WriteLine($"Invalid entry. {2 - counter} attempts remaining.");
                        }
                        else
                        {
                            Console.WriteLine("Attempts exhausted. Returning to main menu.");
                            Thread.Sleep(2000);
                        }
                        counter++;
                    }
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Response attempts exhausted.");
                }
            }
            return false;
        }
    }
}