using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzzLibrary
{
	public class FizzBuzzNumber
	{
		private const String FIZZ = "Fizz";
		private const String BUZZ = "Buzz";

		private int _number;
		private int _fizzDenominator;
		private int _buzzDenominator;

		public FizzBuzzNumber(int number, int fizzDenominator, int buzzDenominator)
		{
			Number = number;
			_fizzDenominator = fizzDenominator;
			_buzzDenominator = buzzDenominator;
		}
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

		private Boolean DivisibleBy(int denominator)
		{
			return Number % denominator == 0 ? true : false;
		}

		private Boolean IsFizz
		{
			get
			{
				return DivisibleBy(_fizzDenominator);
			}
		}

		private Boolean IsBuzz
		{
			get
			{
				return DivisibleBy(_buzzDenominator);
			}
		}

		private Boolean IsFizzBuzz
		{
			get
			{
				return IsFizz && IsBuzz;
			}
		}

		public override string ToString()
		{
			return $"{this.Number}:\t{this.Value}";
		}

	}
}
