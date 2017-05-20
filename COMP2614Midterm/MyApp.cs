using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP2614Midterm
{
	class MyApp
	{
		static void Main(string[] args)
		{
			Run();
		}

		private static void Run()
		{
			var data = Helper.getData();
			Helper.PrintResults(data);

			data.Sort();
			Console.WriteLine();
			Console.WriteLine("After sort: ");
			Console.WriteLine();
			Helper.PrintResults(data);

			Console.ReadLine();
		}
	}
}
