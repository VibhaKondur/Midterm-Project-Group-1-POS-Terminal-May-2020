using System;
using System.Collections.Generic;
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
        }


    }
    } 
