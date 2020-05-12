using System;
using System.Globalization;

namespace Midterm_Project_Group_1_POS_Terminal_May_2020
{
    //PROPERTIES
    class ReceiptCash : Receipt
    {
        CashPayment CashPayment;

        //OVERLOAD CONSTRUCTOR
        public ReceiptCash(CashPayment cashPayment, Cart cart)
        {
            Cart = cart;
            CashPayment = cashPayment;
        }
        //DEFAULT CONSTRUCTOR
        public ReceiptCash() : base() { }
        //METHODS
        public override void PrintReceipt()
        {
            base.PrintReceipt();
            string cashTendered = $"Cash Tendered: {CashPayment.AmountTendered.ToString("C", CultureInfo.CurrentCulture)}";
            string change = $"Change: {CashPayment.ChangeReceived.ToString("C", CultureInfo.CurrentCulture)}";
            Console.WriteLine(cashTendered + "\n" + change);
        }
    }
}
