using System;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Reflection;

using FizzBuzzLibrary;

namespace FizzBuzzConsole
{
	/// <summary>
	/// Used by the Program to parse the command line args.
	/// </summary>
	public class ArgumentParser
	{
		// declare and set the constants
		private const String PATTERN
			  = "(?<=[-{1,2}|\\/])(?<name>[a-zA-Z0-9]*)[\\s|:|\"]*(?<value>[\\w|.|?|=|&|+|\\s|:|\\/|\\\\]*)(?=[\\s|\"]|$)";

		// declare the private _arguments
		private Arguments _arguments;

		/// <summary>
		/// Constructor with no parameters.
		/// </summary>
		public ArgumentParser()
		{

		}

		/// <summary>
		/// Constructor with parameters.
		/// </summary>
		/// <param name="args">String array of args.</param>
		public ArgumentParser(String[] args)
		{
			try
			{
				// parse the args
				Parse(args);
				// validate the arguments
				Arguments.Validate();
			}
			catch (Exception ex)
			{
				// throw exeption to caller
				throw ex;
			}
		}

		/// <summary>
		/// Contains the values of all the Arguments after having been parsed.
		/// </summary>
		public Arguments Arguments
		{
			get
			{
				if (_arguments is null)
				{
					_arguments = new Arguments();
				}
				return _arguments;
			}
			set
			{
				_arguments = value;
			}
		}

		/// <summary>
		/// Used to parse the args.
		/// </summary>
		/// <param name="strArgs"></param>
		private void Parse(String[] args)
		{
			// declare and set _strArgs by "Joining" them with 
			// space as delimeter and Trim the edges
			String _strArgs = String.Join(" ", args).Trim();

			// declare and intitialize the RegEx object
			Regex regEx = new Regex(PATTERN);

			// declare and set matches by searching for Matches
			MatchCollection matches = regEx.Matches(_strArgs);

			// itterate thru the matches
			foreach (Match match in matches)
			{
				// if the match value is empty
				if (match.ToString() != "")
				{
					// switch on the Group's Name value
					switch (match.Groups["name"].ToString().ToLower())
					{
						// check for empty and throws an exception
						case "":
							throw new ArgumentException("An invalid argument was specified.");
							break;
						// check for Start argument name
						case "s":
						case "start":
							Arguments.Start = int.Parse(match.Groups["value"].ToString());
							break;
						// check for Max argument name
						case "m":
						case "max":
							Arguments.Max = int.Parse(match.Groups["value"].ToString());
							break;
						// check for Fizz argument name
						case "f":
						case "fizz":
							Arguments.Fizz = int.Parse(match.Groups["value"].ToString());
							break;
						// check for Buzz argument name
						case "b":
						case "buzz":
							Arguments.Buzz = int.Parse(match.Groups["value"].ToString());
							break;
						// fallout to throw an exception.
						default:
							throw new ArgumentException("An invalid argument was specified.");
							break;
					}
				}
			}

		}

		/// <summary>
		/// Get the Assembly's FileName.
		/// </summary>
		/// <returns>String</returns>
		private static String AssemblyFileName()
		{
			return Path.GetFileName(Assembly.GetExecutingAssembly().CodeBase);
		}

		/// <summary>
		/// Returns a String of Usage information to be displayed to User.
		/// </summary>
		/// <param name="ex">Exception.</param>
		/// <returns>String</returns>
		public static String GetUsage(Exception ex)
		{
			return GetUsage(
				String.Format($"**ERROR: {ex.GetType().ToString()} - {ex.Message}\r\n")
				);
		}

		/// <summary>
		/// Returns a String of Usage information to be displayed to the User.
		/// </summary>
		/// <param name="message">The message to be prepended.</param>
		/// <returns>String</returns>
		public static String GetUsage(String message = "Argument Error")
		{
			// declare and instanciate StringBuilder
			StringBuilder sb = new StringBuilder();
			// append passed in message
			sb.AppendLine(message);
			sb.AppendLine();

			// append USAGE example
			sb.AppendLine("USAGE:");
			sb.AppendLine();
			sb.AppendLine($"Example: {AssemblyFileName()} -m 1000");
			sb.AppendLine();

			// append all possible OPTIONS
			sb.AppendLine("OPTIONS:");
			sb.AppendLine();
			sb.AppendLine("\t-Start\t\tStarting Number (positive integer, default: 1).");
			sb.AppendLine("\t-s\t\tSee: -Start");
			sb.AppendLine();

			sb.AppendLine("\t-Max\t\tMaximum Number (positive integer, default: 100).");
			sb.AppendLine("\t-m\t\tSee: -Max");
			sb.AppendLine();

			sb.AppendLine("\t-Fizz\t\tFizz denominator (positive integer, default: 3).");
			sb.AppendLine("\t-f\t\tSee: -Fizz");
			sb.AppendLine();

			sb.AppendLine("\t-Buzz\t\tBuzz denominator (positive integer, default: 5).");
			sb.AppendLine("\t-b\t\tSee: -Buzz");
			sb.AppendLine();

			// convert the StringBuilder to String and return it
			return sb.ToString();
		}

	}
}
