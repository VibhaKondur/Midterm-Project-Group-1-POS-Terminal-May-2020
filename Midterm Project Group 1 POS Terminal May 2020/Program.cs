using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;

namespace Midterm_Project_Group_1_POS_Terminal_May_2020
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to our Store");
            Console.WriteLine();

            POSController controller = new POSController();
            Cart myCart = new Cart();
            myCart.Display();

            controller.ProductController();

        }
        
       
            

            

    }
}
