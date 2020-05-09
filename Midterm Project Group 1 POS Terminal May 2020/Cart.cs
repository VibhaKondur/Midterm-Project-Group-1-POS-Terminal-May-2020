using System;
namespace Midterm_Project_Group_1_POS_Terminal_May_2020
{
     class Cart
	{
		//PROPERTIES
		public List<box> Boxes { get; set; }
		//OVERLOAD CONSTRUCTOR
		public Boxes(List<box> boxes)
		{
			Boxes = boxes;
		}
		//METHODS
		public void AddBox(Box box)
		{
			boxes.Add(box);
		}
        public double TotalCart()
        {

        }
	}
}
