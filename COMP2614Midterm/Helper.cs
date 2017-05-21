using System;
using System.IO;
using System.Configuration;
using static System.Console;

namespace COMP2614Midterm
{
	/// <summary>
	/// Krzysztof Szczurowski
	/// Helper class, static methods with main functinality;
	/// Repo location: https://github.com/kriss3/BCIT_WinAppDev_COMP2614Midterm.git
	/// </summary>
	class Helper
	{
		#region Public Methods

		/// <summary>
		/// Method to source data from a file;
		/// Folder is stored in App.config, file extension *.csv;
		/// </summary>
		/// <returns>Returns a collection of GoceryItems references</returns>
		public static GroceryItemCollection GetData()
		{
			GroceryItemCollection gic = new GroceryItemCollection();
			var sourceFile = GetSourceFile();
			using (StreamReader sr = new StreamReader(sourceFile))
			{
				while (sr.Peek() > 0)
				{
					var line = sr.ReadLine().Split('|');
					gic.Add(new GroceryItem(line[0], Decimal.Parse(line[1]), GetDate(line[2])));
				}
			}
			return gic;
		}
		public static void SetConsoleTitle()
		{
			Title = $"Hello, {Environment.UserName} - COMP2614 Midterm Project";
		}
		/// <summary>
		/// static method to print/display collection of grocey items
		/// </summary>
		/// <param name="gic">Param containing data payload to display</param>
		public static void PrintResults(GroceryItemCollection gic)
		{
			WriteLine($"{"Grocery Item",-26}{"Price",10}{"",3}{"Expires",-16}");
			PrintDottedLine();
			foreach (var item in gic)
			{
				WriteLine($"{item.Description,-26}{item.Price,10:N2}{"",3}{GetDateValue(item.ExpirationDate),-20}");
			}
			PrintDottedLine();
			WriteLine($"{"Total",-26}{gic.TotalPrice,10:N2}");
		}

		#endregion

		#region Private Methods

		private static string GetSourceFile()
		{
			var fileFolder = ConfigurationManager.AppSettings["filePath"];
			string filter = "*.csv";
			var fileLocation = Directory.GetFiles(fileFolder, filter)[0];
			return fileLocation;
		}
		private static DateTime GetDate(string date)
		{
			DateTime dateValue;
			var temp = DateTime.TryParse(date, out dateValue);
			return (temp) ? dateValue : DateTime.MaxValue;
		}
		private static void PrintDottedLine()
		{
			var length = 55;
			WriteLine(new String('-', length));
		}
		private static string GetDateValue(DateTime date)
		{
			return (date == DateTime.MaxValue) ? "<Never>" : date.ToString("ddd MMM dd, yyyy");
		}
		
		#endregion
	}
}
