using System;
using System.Collections.Generic;
namespace Midterm_Project_Group_1_POS_Terminal_May_2020
{
	//CLASS DECLARATION
	class ProductListView
	{
		//PROPERTIES
		public List<Product> Products { get; set; }
		//CLASS CONSTRUCTOR
		public ProductListView(List<Product> products)
		{
			Products = products;
		}
		//CLASS METHODS
		public void Display()
        //DISPLAY ALL INVENTORY ITEMS IN A NUMBERED LIST.
		{
			Console.WriteLine("Inventory: ");
			for (int i = 0; i < Products.Count; i++)
			{
				Console.WriteLine((i + 1) + ". " + Products[i].Name);
			}
		}
		public Product Select()
		{
            //SELECT AN ITEM FOR PURCHASE
			Console.WriteLine("\nEnter the number of the item you want to buy.");
			
			
			while(true)
			{
				string responseString = Console.ReadLine();
				int responseInt = int.Parse(responseString);
				if (responseInt <= 1 && responseInt >= Products.Count)
				{
					Console.WriteLine("Invalid number. Please enter the number of the item you want to buy.");
				}

				int index = responseInt - 1;
				Product thisProduct = Products[index];
				return thisProduct;

			}
			
		}
	}
}
