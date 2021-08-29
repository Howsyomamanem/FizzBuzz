using System;

using FizzBuzzLibrary;

namespace FizzBuzzConsole
{
	/// <summary>
	/// The default class launched at runtime.
	/// </summary>
	class Program
	{
		/// <summary>
		/// The Main method of the program.
		/// </summary>
		/// <param name="args">Command line arguments.</param>
		static void Main(string[] args)
		{
			// declare ArgumentParser
			ArgumentParser ap;

			try
			{
				// instanciate ArgumentParser
				ap = new ArgumentParser(args);

				// run Fizz Buzz
				RunFizzBuzz(ap.Arguments);

			}
			catch (Exception ex)
			{
				// output Exception information and Usage 
				Console.Write(ArgumentParser.GetUsage(ex));

				// terminate the program with non-zero exit code
				Terminate(1);

			}

			// terminate the program with success exit code 
			Terminate(0);

		}

		/// <summary>
		/// Runs the Fizz Buzz algorythm.
		/// </summary>
		/// <param name="arguments">Parsed and Validated arguments.</param>
		static void RunFizzBuzz(Arguments arguments)
		{
			// output the run header information
			Console.WriteLine("Running with the following arguments...");
			Console.WriteLine($"\tRange: {arguments.Start.ToString("N0")} - {arguments.Max.ToString("N0")}");
			Console.WriteLine($"\tFizz: {arguments.Fizz.ToString("N0")} Buzz: {arguments.Buzz.ToString("N0")}");
			Console.WriteLine();

			// declare and instanciate the FizzBuzzEnumerable
			FizzBuzzEnumerable fb = new FizzBuzzEnumerable(arguments);

			// itterate thru the Numbers
			foreach (FizzBuzzNumber fbn in fb)
			{
				// output result of Number
				Console.WriteLine($"{fbn.ToString()}");

			}

			// output completion message
			Console.WriteLine("Done.");

		}

		/// <summary>
		/// Terminates the program.
		/// </summary>
		/// <param name="exitCode">The exit code to return to the operating system.</param>
		private static void Terminate(int exitCode = 0)
		{
			// if in DEBUG mode, pause for user input
#if DEBUG
			Console.WriteLine("Press any key to terminate...");
			Console.ReadKey();
#endif
			// output exit code
			Environment.Exit(exitCode);
		}
	}
}
