using System;
using System.ComponentModel;
using System.Text.RegularExpressions;
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
            //https://stackoverflow.com/questions/852181/c-printing-all-properties-of-an-object
            foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(DisplayProduct))
            {
                string propertyName = descriptor.Name;
                object value = descriptor.GetValue(DisplayProduct);
                Console.WriteLine($"{propertyName}: {value}");
            }
        }
        public bool Verify(out int quantity)
        {
            if (AskYesOrNo($"\nWould you like to add {DisplayProduct.Name}?"))
            {
                Console.WriteLine($"\nHow many {DisplayProduct.Name} would you like to add?");
                quantity = int.Parse(Console.ReadLine());
                string selectionSummary = ($"\nAre you sure you want to add {quantity} units of {DisplayProduct.Name} to the cart for {quantity * DisplayProduct.Price}?");
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
                
                //theCart.AddBox(BoxUpProduct(quantity));
                Console.WriteLine($"{quantity} units of {DisplayProduct.Name} added to cart.");
            }
        }

        //Box box = new Box(thisProduct, quantity);
                    //return box;

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
    }
}