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
            //INSTANTIATE Cart
            Cart myCart = new Cart(new List<Box> ());
            //INSTANTIATE ProductListView
            ProductListView PLV = new ProductListView(ProductDB);

            //SHOW INVENTORY AND ADD ITEM TO CART
            AddItemToCart(PLV, myCart);

            //Payment newPayment = new Payment();

            bool loop = true;
            while (loop)
            {
                int selection2 = MainMenu.DisplayMenu();
                switch (selection2)
                {
                    case 1: // View Inventory
                        AddItemToCart(PLV, myCart);
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
            }

            //Console.WriteLine();
            //int selection = PLV.Select(); 

            MainMenu MM = new MainMenu();

            while (true)
            {
                int selection3 = MainMenu.DisplayMenu();
            }
        }

        //METHODS
        public static void AddItemToCart(ProductListView PLV, Cart myCart)
        {
        //PRINT A NUMBERED LIST OF INVENTORY PRODUCTS
        PLV.Display();
        //SELECT AN INVENTORY PRODUCT FOR REVIEW
        ProductView PV = new ProductView(PLV.Select());
        //DISPLAY PRODUCT PROPERTEIS
        PV.Display();
        //VERIFY THAT USER WANTS TO PUT PRODUCT IN CART
        //REQUEST QUANTITY TO PUT IN CART
        PV.Verify(out int quantity);
        //PUT PRODUCT IN CART
        myCart.Boxes.Add(new Box(PV.DisplayProduct, quantity));
            Console.WriteLine("Successfully added item.");
            myCart.DisplayCart();
        }
    }
}
