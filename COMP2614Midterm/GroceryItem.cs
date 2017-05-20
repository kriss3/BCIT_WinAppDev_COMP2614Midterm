using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP2614Midterm
{
	class GroceryItem : IComparable<GroceryItem>
	{
		public string Description { get; set; }
		public decimal Price { get; set; }
		public DateTime ExpirationDate { get; set; }

		public int CompareTo(GroceryItem other)
		{
			return (int)this.Price - (int)other.Price;
		}
	}
}
