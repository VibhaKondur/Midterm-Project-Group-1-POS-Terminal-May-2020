//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Midterm_Project_Group_1_POS_Terminal_May_2020
//{
//    class CashPayment : Payment
//    {
//        //public properties
//        public double AmountOfItemPurchased { get; set; }

//        public double AmountTendered { get; set; } 

//        public double ChangeReceived { get; set; }

//        //default constructor
//        public CashPayment()
//        {

//        }

//        //overloaded constructor
//        public CashPayment (double amountOfItemPurchased, double amountTendered, double changeReceived)
//        {
//            AmountOfItemPurchased = amountOfItemPurchased;
//            AmountTendered = amountTendered;
//            ChangeReceived = changeReceived;
//        }

//        //method to have user pay with cash. 
//        //will return a double which is the change the user will get back from the purchase
//        public virtual double PayWithCash()
//        {
//            Console.WriteLine($"Enter amount of item purchased:  ");
//            double amountOfItemPurchased = double.Parse(Console.ReadLine());

//            Console.WriteLine($"Enter cash amount to pay:   ");
//            double amountTendered = double.Parse(Console.ReadLine());

//            Console.WriteLine($"Here's your change:   ");
//            double changeReceived = double.Parse(Console.ReadLine());           
            
//            changeReceived = amountTendered - amountOfItemPurchased;

//            return changeReceived;
//        }
//    }
//}
