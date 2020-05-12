using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
namespace Midterm_Project_Group_1_POS_Terminal_May_2020
{
    class CashPayment : Payment
    {
        //public properties
        public double AmountOfItemPurchased { get; set; }
        public double AmountTendered { get; set; }
        public double ChangeReceived { get; set; }
        public double Cart { get; set; }
        //default constructor
        public CashPayment()
        {
        }
        //overloaded constructor
        public CashPayment(double amountOfItemPurchased, double amountTendered, double changeReceived, double cart)
        {
            AmountOfItemPurchased = amountOfItemPurchased;
            AmountTendered = amountTendered;
            ChangeReceived = changeReceived;
            Cart = cart;
        }
        //method to have user pay with cash.
        //will return a double which is the change the user will get back from the purchase
        public double PayWithCash(Cart myCart)
        {
            //1. Prints total
            // Console.WriteLine(myCart);
            Console.WriteLine($"Subtotal: {myCart.Subtotal().ToString("C", CultureInfo.CurrentCulture)}");
            Console.WriteLine($"Enter cash amount to pay: ");
            double amountTendered = double.Parse(Console.ReadLine());
            ChangeReceived = amountTendered - myCart.Subtotal();
            Console.WriteLine($"Here's your change: {ChangeReceived}");
            // myCart.Subtotal();
            //double changeReceived = double.Parse(Console.ReadLine());
            return ChangeReceived;
            //Enter amount of cash to be tendered
            //
            // Console.WriteLine($"Enter amount of item purchased:  ");
            //// double amountOfItemPurchased = double.Parse(Console.ReadLine());
            //changeReceived = amountTendered - amountOfItemPurchased;
            // return changeReceived;
        }
    }
}
