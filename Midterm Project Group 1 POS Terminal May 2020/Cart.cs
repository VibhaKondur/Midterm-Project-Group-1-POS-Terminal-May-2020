using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
namespace Midterm_Project_Group_1_POS_Terminal_May_2020
{
	class Cart
	{
		//PROPERTIES
		public List<Box> Boxes { get; set; }
		//OVERLOAD CONSTRUCTOR
		public Cart(List<Box> boxes)
		{
			Boxes = boxes;
		}
		//DEFAULT CONSTRUCTOR
		public Cart() { }
		//METHODS
		List<Box> boxes = new List<Box>();
		public void AddBox(Box box)
		{
			Boxes.Add(box);
		}
		public void DisplayCart()
		{
			Console.WriteLine("Cart Contents: ");
			for (int i = 0; i < boxes.Count; i++)
			{
				Console.WriteLine((i + 1) + ". " + boxes[i].Product);
			}
		}
		public int SelectItem(string action)
		{
			DisplayCart();
			Console.WriteLine($"Which cart item would you like to {action}?");
			if (ValidateIntRange("an item number", Boxes.Count, out int index))
			{
				return index;
			}
			else
			{
				return -1;
				throw new Exception("Formatting error.");
			}
		}
		public void RemoveBox()
		{
			int index = SelectItem("remove");
			Console.WriteLine($"How many {Boxes[index].Product.Name} would you like to remove from the cart?");
			ValidateIntRange("a quantity to remove", Boxes[index].Quantity, out int quantityToRemove);
			if (quantityToRemove == Boxes[index].Quantity)
			{
				Console.WriteLine($"All units of {Boxes[index].Product.Name} have been removed from the cart. ");
				Boxes.RemoveAt(index);
			}
			else
			{
				Boxes[index].Quantity -= quantityToRemove;
				Console.WriteLine($"{quantityToRemove} units of {Boxes[index].Product.Name} have been removed from the cart. ");
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
		public void Clear()
		{
			Boxes.Clear();
			Console.WriteLine("All items have been removed from the cart.");
		}
		public static bool ValidateIntRange(string valueDescription, int range, out int index)
		{
			if (int.TryParse(Console.ReadLine().Trim(), out int integer))
			{
				if (integer >= 0 && integer <= range)
				{
					//Console.WriteLine($"{input} is an integer within the range of 1-{range}.");
					index = integer - 1;
					return true;
				}
				else
				{
					Console.WriteLine("Index out of range exception.");
					throw new IndexOutOfRangeException();
				}
			}
			else
			{
				Console.WriteLine("Format exception.");
				throw new FormatException();
			}
		}
		public static bool ValidateWRegEx(string valueDescription, string regExString, string input)
		{
			Regex regEx = new Regex($@"{regExString}");
			if (regEx.IsMatch(input))
			{
				//Console.WriteLine($"{input} is a {valueDescription}.");
				return true;
			}
			else
			{
				//Console.WriteLine($"{input} is not a {valueDescription}.");
				return false;
			}
		}
		public static bool ValidationLoop(string valueDescription, List<Box> list, out int index)
		{
			//This validation loop overload is intended for use when a user must select from a numbered list of options. This overload accepts a string parameter "valueDescription" which is concatenated into the user prompt for specificity. This overload accepts a List<> parameter "list" which provides the acceptable range of integers from which the user may choose. This overload returns boolean value "true" if the user input is indeed an integer within the index range of the list, and "false" if not. This overload also returns an int "index", which equals the user input minus 1.
			//This validation loop references the method "ValidateWRegEx."
			bool valid = false;
			string input = null;
			int counter = 0;
			//\b[1-[\d]*\b
			string regEx = "\\b[1-" + $"[{list.Count()}]*" + "]\\b";
			while (!valid && counter <= 2)
			{
				Console.WriteLine($"Enter {valueDescription} (#1-{list.Count()}): ");
				input = Console.ReadLine().Trim();
				if (ValidateIntRange(valueDescription, list.Count(), out int integer))
				{
					index = integer - 1;
					valid = true;
					return true;
				}
				else
				{
					Console.WriteLine($"Invalid entry. {2 - counter} attempts remaining.");
					counter++;
				}
			}
			index = -1;
			return false;
		}
	}
}