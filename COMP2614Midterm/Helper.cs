using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Configuration;
using static System.Console;

namespace COMP2614Midterm
{
	class Helper
	{
		public static void Greatings()
		{
			WriteLine($"Hello, {Environment.UserName}");
			ReadLine();
		}

		public static GroceryItemCollection getData()
		{
			GroceryItemCollection gic = new GroceryItemCollection();
			var sourceFile = getSourceFile();
			var myDateTime = DateTime.MaxValue;
			using (StreamReader sr = new StreamReader(sourceFile))
			{
				while (sr.Peek() > 0)
				{
					var line = sr.ReadLine().Split('|');
					gic.Add(new GroceryItem { Description = line[0], Price = Decimal.Parse(line[1]), ExpirationDate = getDate(line[2])});
				}
			}
			return gic;
		}

		private static string getSourceFile()
		{
			var fileFolder = ConfigurationManager.AppSettings["filePath"];
			string filter = "*.csv";
			var fileLocation = Directory.GetFiles(fileFolder, filter)[0];
			return fileLocation;
		}

		private static DateTime getDate(string date)
		{
			var result = DateTime.MaxValue;
			var temp = DateTime.TryParse(date, out result);

			return result; ;
		}

		public static void PrintResults(GroceryItemCollection gic)
		{
			//Print header
			WriteLine($"{"Description", -20}{"Price",10}{"Expiration",15}");
			PrintDottedLine();
			foreach (var item in gic)
			{
				WriteLine($"{item.Description,-20}{item.Price,10:N2}{item.ExpirationDate,15:yyyy/MM/dd}");
			}
		}

		private static void PrintDottedLine()
		{
			var length = 45;
			WriteLine(new String('-', length));
		}
	}
}
