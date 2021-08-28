using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
//using System.Threading.Tasks;

namespace FizzBuzzLibrary
{
	public class ArgumentParser
	{
		private const String PATTERN
			  = "(?<=[-{1,2}|\\/])(?<name>[a-zA-Z0-9]*)[\\s|:|\"]*(?<value>[\\w|.|?|=|&|+|\\s|:|\\/|\\\\]*)(?=[\\s|\"]|$)";

		private Arguments _arguments;

		public ArgumentParser()
		{

		}

		public ArgumentParser(String[] args)
		{
			String _strArgs = String.Join(" ", args).Trim();

			try
			{
				Parse(_strArgs);
				Arguments.Validate();
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

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

		private void Parse(String strArgs)
		{
			Regex regEx = new Regex(PATTERN);
			//regEx.Options = RegexOptions.

			MatchCollection matches = regEx.Matches(strArgs);

			foreach (Match match in matches)
			{
				if (match.ToString() != "")
				{
					switch (match.Groups["name"].ToString().ToLower())
					{
						case "":
							throw new ArgumentException("An invalid argument was specified.");
							break;
						case "s":
						case "start":
							Arguments.Start = int.Parse(match.Groups["value"].ToString());
							break;
						case "m":
						case "max":
							Arguments.Max = int.Parse(match.Groups["value"].ToString());
							break;
						case "f":
						case "fizz":
							Arguments.Fizz = int.Parse(match.Groups["value"].ToString());
							break;
						case "b":
						case "buzz":
							Arguments.Buzz = int.Parse(match.Groups["value"].ToString());
							break;
						default:
							throw new ArgumentException("An invalid argument was specified.");
							break;
					}
				}
			}

		}

		private static String AssemblyFileName()
		{
			return Path.GetFileName(Assembly.GetExecutingAssembly().CodeBase);
		}


		public static String GetUsage(Exception ex)
		{
			return ShowUsage(
				String.Format($"**ERROR: {ex.GetType().ToString()} - {ex.Message}\r\n")
				);
		}

		public static String ShowUsage(String message = "Argument Error")
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendLine(message);
			sb.AppendLine();

			sb.AppendLine("USAGE:");
			sb.AppendLine();
			sb.AppendLine($"Example: {AssemblyFileName()} -m 1000");
			sb.AppendLine();

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

			return sb.ToString();
		}

	}

	public class Arguments
	{
		public int Start { get; set; } = 1;
		public int Max { get; set; } = 100;
		public int Fizz { get; set; } = 3;
		public int Buzz { get; set; } = 5;

		//validate arguments
		public void Validate()
		{
			if (!ValidatePositive(Start))
				throw new ArgumentOutOfRangeException("Start", "Must be positive.");

			if (!ValidatePositive(Max))
				throw new ArgumentOutOfRangeException("Max", "Must be positive.");

			if (!ValidatePositive(Fizz))
				throw new ArgumentOutOfRangeException("Fizz", "Must be positive.");

			if (!ValidatePositive(Buzz))
				throw new ArgumentOutOfRangeException("Buzz", "Must be positive.");

			if (Start >= Max)
				throw new ArgumentException("Start must be less than Max.");

			if (Fizz >= Buzz)
				throw new ArgumentException("Fizz must be less than Buzz.");

			//if (Fizz < Start || Fizz > Max)
			//	throw new ArgumentException("Fizz must be between Start and Max.");

			//if (Buzz < Start || Buzz > Max)
			//	throw new ArgumentException("Buzz must be between Start and Max.");

			if (Fizz >= Max)
				throw new ArgumentException("Fizz must be less than Max.");

			if (Buzz >= Max)
				throw new ArgumentException("Buzz must be less than Max.");

		}

		private Boolean ValidatePositive(int value)
		{
			return value > 0 ? true : false;
		}

	}

}
