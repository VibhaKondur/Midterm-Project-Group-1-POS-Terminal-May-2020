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
            FileIO number1 = new FileIO();
            ProductDB = number1.ReadFromInventory();

            //NewMethod(ProductDB);
            //int inventorySelect = int.Parse(Console.ReadLine());
            ProductListView PLV = new ProductListView(ProductDB);
            PLV.Display();
            PLV.Select();
            ProductView PV = new ProductView();
            Cart myCart = new Cart();
            PV.Verify(out int quantity);
            PV.OfferToAddToCart(myCart);
            //Something here
            int selection2 = MainMenu.DisplayMenu();

            //Payment newPayment = new Payment();

            switch (selection2)
            {
                case 1: // View Inventory
                    PLV.Display();
                    break;
                case 2: //Remove from cart
                    myCart.RemoveBox();
                    break;
                case 3:// Review
                    myCart.DisplayCart();
                    break;
                case 4:// checkout
                    double subtotal = myCart.Subtotal();
                    //newPayment.SelectPaymentMethod();
                    Payment.SelectPaymentMethod();
                    break;
                case 5: // clear cart
                    myCart.Clear();
                    break;
            }
            //List<Box> newBox = new List<Box>();
            //Console.WriteLine();
            //int selection = PLV.Select(); 

            //ProductView PV = new ProductView(ProductDB[selection]);
            //PV.OfferToAddToCart(myCart);

            //myCart.Display();
            //int cart = myCart.AddBox(Box);


            MainMenu MM = new MainMenu();



            while (true)
            {
                int selection3 = MainMenu.DisplayMenu();

            }
        }

        //public static void NewMethod(List<Product> products)
        //{
        //    ProductListView PLV = new ProductListView(products);
        //    PLV.Display();

        //}
    }
}
