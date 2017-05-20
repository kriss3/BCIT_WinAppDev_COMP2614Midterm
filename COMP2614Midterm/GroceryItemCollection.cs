using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP2614Midterm
{
	class GroceryItemCollection : List<GroceryItem>
	{
		public decimal TotalPrice
		{
			get
			{
				var temp = 0.0m;
				foreach (var i in this)
				{
					temp += i.Price;
				}
				return temp;
			}
		}

	}
}
