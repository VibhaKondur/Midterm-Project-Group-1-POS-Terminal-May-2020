using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Text;

namespace Midterm_Project_Group_1_POS_Terminal_May_2020
{
    class POSController
    {


        public List<Product> ProductDB = new List<Product>();
        public void ProductController()
        {
            Cart myCart = new Cart();
            FileIO number1 = new FileIO();

            ProductDB = number1.ReadFromInventory();

            NewMethod(ProductDB);

            ProductListView PLV = new ProductListView(ProductDB);

            Console.WriteLine();
            int selection = PLV.Select();

            ProductView PV = new ProductView(ProductDB[selection]);

            PV.OfferToAddToCart(myCart);

            myCart.Display();
            //int cart = myCart.AddBox(Box);


            MainMenu MM = new MainMenu();



            while (true)
            {
            int selection2 = MainMenu.DisplayMenu();

                

            //switch (selection2)
            //{
            //    case "1": // View Inventory
            //            NewMethod(ProductDB);
            //    case "2": //Remove from cart
            //       // myCart
            //    case "3":// Review

            //    case "4":// checkout
            //    case "5": // clear cart
            //}

            }


        }

        public static void NewMethod(List<Product> products)
        {
            ProductListView PLV = new ProductListView(products);
            PLV.Display();

        }





    }
}
