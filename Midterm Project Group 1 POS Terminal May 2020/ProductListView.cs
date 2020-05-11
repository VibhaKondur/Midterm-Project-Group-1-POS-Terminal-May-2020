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
			int responseInt = -1;
			
			//SELECT AN ITEM FOR PURCHASE
			while (true)
			{
				try
				{
					Console.WriteLine("\nEnter the number of the item you want to buy.");
					string responseString = Console.ReadLine();
					responseInt = int.Parse(responseString);
					int index = responseInt - 1;
					Product thisProduct = Products[index];
					return thisProduct;
				}
				catch (ArgumentOutOfRangeException)
				{
					Console.WriteLine("I'm sorry, that does not appear to be a product in our inventory. ");
				}
				catch (IndexOutOfRangeException)
				{
					Console.WriteLine("I'm sorry, that does not appear to be a product in our inventory. ");
				}
				catch (FormatException)
				{
					Console.WriteLine("Invalid input. Please enter a number.");
				}

			}
			
		}
	}
}
