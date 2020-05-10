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
        public bool Verify(out int quantity)
        {
            Display();
            if (AskYesOrNo($"Would you like to add {thisProduct.Name}?"))
            {
                quantity = ValidateIntRange($"the quantity of {thisProduct.Name} you would like to add", thisProduct.Inventory);
                string selectionSummary = ($"Would you like to add {quantity} units of {thisProduct.Name}?");
                if (AskYesOrNo(selectionSummary))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                quantity = 0;
                return false;
            }
        }

        public void OfferToAddToCart(Cart theCart)
        {
            if (Verify(out int quantity))
            {
                Box boxToCart = new Box(thisProduct, quantity);
                theCart.AddBox(boxToCart);
            }
        }

        //Box box = new Box(thisProduct, quantity);
                    //return box;

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
        public static int ValidateIntRange(string valueDescription, int range)
        {
            bool valid = false;
            while (!valid)
            {
                if (int.TryParse(Console.ReadLine().Trim(), out int integer))
                {
                    if (integer >= 0 && integer <= range)
                    {
                        //Console.WriteLine($"{input} is an integer within the range of 1-{range}.");
                        int index = integer - 1;
                        valid = true;
                        return index;
                    }
                    else
                    {
                        Console.WriteLine("Input is out of range. Try again.");
                        valid = false;
                    }
                }
                else
                {
                    Console.WriteLine("Format exception. Try again.");
                    valid = false;
                }
            }
            return -1;
        }
    }
}