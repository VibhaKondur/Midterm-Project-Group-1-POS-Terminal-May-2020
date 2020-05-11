using System;
using System.Collections.Generic;
using System.Globalization;

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
				//Console.WriteLine((i + 1) + ". " + Products[i].Name + " " + Products[i].Price.ToString("C", CultureInfo.CurrentCulture));
                //INDENTATION
                string number = ((i + 1) + ". ").ToString();
                string name = Products[i].Name;
                string price = Products[i].Price.ToString("C", CultureInfo.CurrentCulture);
				string column1 = number;
				string column2 = name;
				string column3 = price;
                //COLUMN 1
                Console.Write(column1);
                //COLUMN 2
				Console.Write(column2.PadLeft(10 - column1.Length));
                //COLUMN 3
				Console.WriteLine(column3.PadLeft(60 - column2.Length - column1.Length));
			}
		}
		public Product Select()
		{
				
			//while(true)
			//{
			//	string responseString = Console.ReadLine();
			//	int responseInt = int.Parse(responseString);
			//	if (responseInt <= 1 && responseInt >= Products.Count)
			//	{
			//		Console.WriteLine("Invalid number. Please enter the number of the item you want to buy.");
			//	}

			//	int index = responseInt - 1;
			//	Product thisProduct = Products[index];
			//	return thisProduct;

			//int responseInt = -1;
			
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
