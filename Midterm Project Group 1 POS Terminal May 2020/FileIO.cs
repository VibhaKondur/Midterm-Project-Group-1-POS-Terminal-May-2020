using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Midterm_Project_Group_1_POS_Terminal_May_2020
{
    class FileIO
    {
        public List<Product> ReadFromInventory()
        {
            StreamReader reader = new StreamReader("../../../ProductDatabase.txt");
            List<Product> inventory = new List<Product>();
            string line = reader.ReadLine();
            while(line != null)
            {
                string[] inventoryLine = line.Split('|');
                inventory.Add(new Product(inventoryLine[0], inventoryLine[1], inventoryLine[2], int.Parse(inventoryLine[3]), double.Parse(inventoryLine[4])));
                line = reader.ReadLine();
            }
            reader.Close();
            return inventory;

        }

        public void WriteToInventory(List<Product> updatedInventory)
        {
            StreamWriter writer = new StreamWriter("../../../ProductDatabase.txt");
            foreach(Product line in updatedInventory)
            {
                writer.WriteLine($"{line.Name}|{line.Category}|{line.Description}|{line.Inventory}|{line.Price}");
            }
            writer.Close();
        }
    }
}
