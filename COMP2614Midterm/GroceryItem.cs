using System;

namespace COMP2614Midterm
{
	/// <summary>
	/// Krzysztof Szczurowski
	/// Class representing GroceyItems; class implementing IComparable interface;
	/// Repo Location: https://github.com/kriss3/BCIT_WinAppDev_COMP2614Midterm.git
	/// </summary>
	class GroceryItem : IComparable<GroceryItem>
	{
		public string Description { get; private set; }
		public decimal Price { get; set; }
		public DateTime ExpirationDate { get; private set; }
		public GroceryItem(string description, decimal price, DateTime expiry)
		{
			Description = description;
			Price = price;
			ExpirationDate = expiry;
		}
		public int CompareTo(GroceryItem other)
		{
			return (int)other.Price - (int)this.Price;
		}
	}
}