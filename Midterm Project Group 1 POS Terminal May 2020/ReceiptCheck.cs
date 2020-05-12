using System;
using System.Globalization;

namespace Midterm_Project_Group_1_POS_Terminal_May_2020
{
    //PROPERTIES
    class ReceiptCheck : Receipt
    {
        public CheckPayment CheckPayment;
        //OVERLOAD CONSTRUCTOR
        public ReceiptCheck(CheckPayment checkPayment, Cart cart)
        {
            Cart = cart;
            CheckPayment = checkPayment;
        }
        //DEFAULT CONSTRUCTOR
        public ReceiptCheck() : base() { }
        //METHODS
        public override void PrintReceipt()
        {
            base.PrintReceipt();
            string name = $"Name: {CheckPayment.Name}";
            string checkNumber = $"Check Number: {CheckPayment.CheckNumber}";
            Console.WriteLine(name + "\n" + checkNumber);
        }
    }
}
