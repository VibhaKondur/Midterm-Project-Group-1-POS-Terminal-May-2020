using System;
using System.Collections.Generic;
using System.Globalization;
namespace Midterm_Project_Group_1_POS_Terminal_May_2020
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Globalization;
    using System.Text.RegularExpressions;

    //CLASS DECLARATION
    class ProductView
    {
        //PROPERTIES
        public Product thisProduct { get; set; }
        //CONSTRUCTOR
        public ProductView(Product displayProduct)
        {
            thisProduct = displayProduct;
        }
        //CLASS METHODS
        public void Display()
        {
            //PRINT OUT ALL THE PROPERTIES AND VALUES OF PRODUCT
            //https://stackoverflow.com/questions/852181/c-printing-all-properties-of-an-object
            foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(thisProduct))
            {
                string propertyName = descriptor.Name;
                object value = descriptor.GetValue(thisProduct);
                Console.WriteLine($"{propertyName}: {value}");
            }
        }
        public Box Select()
        {
            Cart myCart = new Cart();

            Display();
            if (AskYesOrNo("Would you like to purchase this item?"))
            {
                if (ValidationLoop("the quantity you would like to purchase", thisProduct.Inventory, out int quantity))
                {
                }
                else
                {
                    //throw new Exception("Index out of range.");
                }
                string selectionSummary = ($"Would you like to add {quantity + 1} units of {thisProduct.Name} (total price: { (quantity + 1) * thisProduct.Price}) to the cart ?");
                if (AskYesOrNo(selectionSummary))
                {
                    Box box = new Box(thisProduct, quantity + 1);
                return box;
                }
                else
                {
                }
            }
            Box emptyBox = new Box();
            return emptyBox;
        }
            

        public static bool ValidateWRegEx(string valueDescription, string regExString, string input)
        {
            Regex regEx = new Regex($@"{regExString}");

            if (regEx.IsMatch(input))
            {
                //Console.WriteLine($"{input} is a {valueDescription}.");
                return true;
            }
            else
            {
                //Console.WriteLine($"{input} is not a {valueDescription}.");
                return false;
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
                Regex yesTrue = new Regex(@"\b((y(es)?)|\b(t(rue)?))\b");
                Regex noFalse = new Regex(@"\b((n(o)?)|(f(alse)?))\b");
                try
                {
                    if (yesTrue.IsMatch(response))
                    {
                        loop = false;
                        return true;
                    }
                    if (noFalse.IsMatch(response))
                    {
                        loop = false;
                        return false;
                    }
                    else
                    {
                        Console.WriteLine($"Invalid entry. {2 - counter} attempts remaining.");
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
        public static bool ValidationLoop(string valueDescription, int inventory, out int index)
        {
            //This validation loop overload is intended for use when a user must select from a numbered list of options. This overload accepts a string parameter "valueDescription" which is concatenated into the user prompt for specificity. This overload accepts a List<> parameter "list" which provides the acceptable range of integers from which the user may choose. This overload returns boolean value "true" if the user input is indeed an integer within the index range of the list, and "false" if not. This overload also returns an int "index", which equals the user input minus 1.
            //This validation loop references the method "ValidateWRegEx."
            bool valid = false;
            string input = null;
            int counter = 0;
           // string regEx = "\\b[1-" + $"{inventory}" + "]\\b";
            while (!valid && counter <= 2)
            {
                Console.WriteLine($"Enter {valueDescription} (#1-{inventory}): ");
                input = Console.ReadLine().Trim();
                if (ValidateIntRange(valueDescription, inventory, input))
                {
                    index = int.Parse(input) - 1;
                    valid = true;
                    return true;
                }
                else
                {
                    Console.WriteLine($"Invalid entry. {2 - counter} attempts remaining.");
                    counter++;
                }
            }
            index = -1;
            return false;
        }
        public static bool ValidateIntRange(string valueDescription, int range, string input)
        {
            if (int.TryParse(input, out int integer))
            {
                if (integer >= 1 && integer <= range)
                {
                    //Console.WriteLine($"{input} is an integer within the range of 1-{range}.");
                    return true;
                }
                else
                {
                    throw new IndexOutOfRangeException();
                    Console.WriteLine("Index out of range exception.");
                }
            }
            else
            {
                throw new FormatException();
                Console.WriteLine("Format exception.");
            }
        }

    }
}