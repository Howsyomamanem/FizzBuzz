using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzzLibrary
{
	/// <summary>
	/// The parser for the current number.
	/// </summary>
	public class FizzBuzzNumber
	{
		// declare and set constants
		private const String FIZZ = "Fizz";
		private const String BUZZ = "Buzz";

		// declare privates
		private int _number;
		private int _fizzDenominator;
		private int _buzzDenominator;

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="number">The current number.</param>
		/// <param name="fizzDenominator">The Fizz Denominator.</param>
		/// <param name="buzzDenominator">The Buzz Denominator.</param>
		public FizzBuzzNumber(int number, int fizzDenominator, int buzzDenominator)
		{
			Number = number;
			_fizzDenominator = fizzDenominator;
			_buzzDenominator = buzzDenominator;
		}

		/// <summary>
		/// The read/write current number we're analyzing.
		/// </summary>
		public int Number
		{
			get
			{
				return _number;
			}
			set
			{
				_number = value;
			}
		}

		/// <summary>
		/// The read-only String value of the Number property
		/// </summary>
		public String Value
		{
			get
			{
				if (IsFizzBuzz)
				{
					// return the Fizz Buzz String
					return String.Format($"{FIZZ} {BUZZ}");

				}
				if (IsFizz)
				{
					// return the Fizz String
					return FIZZ;

				}
				if (IsBuzz)
				{
					// return the Buzz String
					return BUZZ;

				}

				// return the number formatted with commas
				return Number.ToString("N0"); 
			}
		}

		/// <summary>
		/// True if the Number property is divisible by the given denominator.
		/// </summary>
		/// <param name="denominator">The value to divid the Number property by.</param>
		/// <returns></returns>
		private Boolean DivisibleBy(int denominator)
		{
			return Number % denominator == 0 ? true : false;
		}

		/// <summary>
		/// True if the Nubmer property is Fizz.
		/// </summary>
		private Boolean IsFizz
		{
			get
			{
				return DivisibleBy(_fizzDenominator);
			}
		}

		/// <summary>
		/// True if the Number property is Buzz.
		/// </summary>
		private Boolean IsBuzz
		{
			get
			{
				return DivisibleBy(_buzzDenominator);
			}
		}

		/// <summary>
		/// True if the Number property is both Fizz and Buzz.
		/// </summary>
		private Boolean IsFizzBuzz
		{
			get
			{
				return IsFizz && IsBuzz;
			}
		}

		/// <summary>
		/// Returns the Display version of the FizzBuzzNumber.
		/// </summary>
		/// <returns>String</returns>
		public override String ToString()
		{
			return $"\t{this.Number}:\t{this.Value}";
		}

	}
}
