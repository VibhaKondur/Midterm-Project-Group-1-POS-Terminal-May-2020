using System;
using System.Collections.Generic;
using System.Text;

namespace Midterm_Project_Group_1_POS_Terminal_May_2020
{
    class Product
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public int Inventory { get; set; }
        public double Price { get; set; }
        //Default Constructor
        public Product() { }
        //Constructor
        public Product(string _name, string _category, string _description, int _inventory, double _price)
        {
            Name = _name;
            Category = _category;
            Description = _description;
            Inventory = _inventory;
            Price = _price;
        }
    }
}
