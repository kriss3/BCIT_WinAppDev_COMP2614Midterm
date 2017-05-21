using System;
using System.IO;
using static System.Console;

namespace COMP2614Midterm
{
	/// <summary>
	/// Driver class, calling Helper class static methods for functinality;
	/// Repo location: https://github.com/kriss3/BCIT_WinAppDev_COMP2614Midterm.git
	/// </summary>
	class MyApp
	{
		static void Main(string[] args)
		{
			Run();
		}
		private static void Run()
		{
			Helper.SetConsoleTitle();
			WriteLine();
			GroceryItemCollection data = null;
			try
			{
				data = Helper.GetData();
			}
			catch (DirectoryNotFoundException dEx)
			{
				ForegroundColor = ConsoleColor.Red;
				WriteLine(dEx.Message);
				ReadLine();
			}
			catch (Exception ex)
			{
				ForegroundColor = ConsoleColor.Red;
				WriteLine(ex.Message);
				ReadLine();
			}

			if (data == null)
			{
				return;
			}
			ForegroundColor = ConsoleColor.Red;
			WriteLine("Natural Order:");
			ForegroundColor = ConsoleColor.Gray;
			Helper.PrintResults(data);
			data.Sort();
			WriteLine("\n\n");
			ForegroundColor = ConsoleColor.Red;
			WriteLine("Sorted Order: [Price Descending]");
			ForegroundColor = ConsoleColor.Gray;
			Helper.PrintResults(data);
			ReadLine();
		}
	}
}
