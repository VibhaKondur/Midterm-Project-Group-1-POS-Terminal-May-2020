using System;
using System.Collections.Generic;
namespace Midterm_Project_Group_1_POS_Terminal_May_2020
{
	using System.Collections.Generic;
	using System.Linq;
	using System.Text.RegularExpressions;

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
		{
			Console.WriteLine("Inventory: ");
			for (int i = 0; i < Products.Count; i++)
			{
				Console.WriteLine((i + 1) + ". " + Products[i].Name);
			}
		}
		public int Select()
		{
			Display();
			if (ValidationLoop("an item by number", Products, out int index))
			{
				return index;
			}
			else
			{
				return -1;
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
		public static bool ValidateIntRange(string valueDescription, int range, string input)
		{
			if (int.TryParse(input, out int integer))
			{
				if (integer >= 1 && integer <= range)
				{
					//Console.WriteLine($"{input} is an integer within the range of 1-{range}.");
					return true;
				}
				else
				{
					throw new IndexOutOfRangeException(e);
					Console.WriteLine("Index out of range exception.");
				}
			}
			else
			{
				throw new FormatException();
				Console.WriteLine("Format exception.");
			}
		}
		public static bool ValidationLoop(string valueDescription, List<Product> list, out int index)
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
				if (ValidateIntRange(valueDescription, list.Count(), input))
				{
					index = int.Parse(input) - 1;
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
