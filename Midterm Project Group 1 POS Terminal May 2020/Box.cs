﻿using System;
namespace Midterm_Project_Group_1_POS_Terminal_May_2020
{
    class Box
    {
        //PROPERTIES
        public Product Product { get; set; }
        public int Quantity { get; set; }
        //OVERLOAD CONSTRUCTOR
        public Box(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }
        //DEFAULT CONSTRUCTOR
        public Box() {}
        //METHOD
        public double Price()
        {
            double price = Product.Price * Quantity;
            return price;
        }
    }
}
