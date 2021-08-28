﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FizzBuzzLibrary;

namespace FizzBuzzConsole
{
	class Program
	{
		static void Main(string[] args)
		{
			// arguments
			ArgumentParser ap;
			try
			{
				ap = new ArgumentParser(args);
				Run(ap.Arguments);
			}
			catch (Exception ex)
			{
				Console.Write(ArgumentParser.GetUsage(ex));
				Terminate(1);
			}

			Console.WriteLine("Done.");
			Terminate(0);
		}

		static void Run(Arguments arguments)
		{
			FizzBuzzEnumerable fb = new FizzBuzzEnumerable(arguments);

			foreach (FizzBuzzNumber fbn in fb)
			{
				Console.WriteLine($"{fbn.ToString()}");
			}

		}

		private static void Terminate(int exitCode = 0)
		{
#if DEBUG
			Console.WriteLine("Press any key to terminate...");
			Console.ReadKey();
#endif
			Environment.Exit(exitCode);
		}
	}
}