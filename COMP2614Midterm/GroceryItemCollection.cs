using System.Collections.Generic;

namespace COMP2614Midterm
{
	/// <summary>
	/// Krzysztof Szczurowski
	/// GorceyItemCollecton, a wrapper class around List of GroceyItems
	/// Adding additional calculated property TotaPrice;
	/// Repo location: https://github.com/kriss3/BCIT_WinAppDev_COMP2614Midterm.git
	/// </summary>
	class GroceryItemCollection : List<GroceryItem>
	{
		public decimal TotalPrice
		{
			get
			{
				var total = 0.0m;
				foreach (var i in this)
				{
					total += i.Price;
				}
				return total;
			}
		}
	}
}
