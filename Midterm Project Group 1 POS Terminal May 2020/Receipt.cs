using System;
using System.Globalization;

namespace Midterm_Project_Group_1_POS_Terminal_May_2020
{
    abstract class Receipt
    {
        //PROPERTIES
        public Cart Cart { get; set; }
        //OVERLOADED CONSTRUCTOR
        public Receipt(Cart cart)
        {
            Cart = cart;
        }
        //DEFAULT CONSTRUCTOR
        public Receipt() { }
        //METHODS
        public virtual void PrintReceipt()
        {
            string orderContents = Cart.GetReceipt();
            double tax = (Cart.Subtotal() * 0.06);
            double total = Cart.Subtotal() + tax;
            Console.WriteLine(orderContents + "\n" + "Tax: " + tax.ToString("C", CultureInfo.CurrentCulture) + "\n" + "Total: " + total.ToString("C", CultureInfo.CurrentCulture));
        }
    }
}
