using System;
using System.Collections.Generic;

namespace Midterm_Project_Group_1_POS_Terminal_May_2020
{
	class Cart
	{
		//PROPERTIES
		public List<Box> Boxes { get; set; }
		//OVERLOAD CONSTRUCTOR
		public Cart()
		{

		}
		public Cart(List<Box> boxes)
		{
			Boxes = boxes;
		}
		//METHODS
		public void AddBox(Box box)
		{
			Boxes.Add(box);
		}
		public void RemoveBox()
		{
			Console.WriteLine("Which item would you like to remove from the cart?");
		}
		public void Display()
		{
			Console.WriteLine("Cart Contents: ");
			for (int i = 0; i < Boxes.Count; i++)
			{
				Console.WriteLine((i + 1) + ". " + Boxes[i].Product);
			}
		}


		public double Subtotal()
		{
			double subtotal = 0;
			foreach (Box box in Boxes)
			{
				subtotal += box.Price();
			}
			return subtotal;
		}
	}
}
