using System;

namespace FizzBuzzLibrary
{
	/// <summary>
	/// Contains properties for all possible arguments.
	/// </summary>
	public class Arguments
	{
		// initialize and set default values for all properties
		public int Start { get; set; } = 1;
		public int Max { get; set; } = 100;
		public int Fizz { get; set; } = 3;
		public int Buzz { get; set; } = 5;

		// validate arguments
		public void Validate()
		{
			// check that the Start property is a positive integer
			if (!ValidatePositive(Start))
				throw new ArgumentOutOfRangeException("Start", "Must be positive.");

			// check that the Max property is a positive integer
			if (!ValidatePositive(Max))
				throw new ArgumentOutOfRangeException("Max", "Must be positive.");

			// check that the Fizz property is a positive integer
			if (!ValidatePositive(Fizz))
				throw new ArgumentOutOfRangeException("Fizz", "Must be positive.");

			// check that the Buzz property is a positive integer
			if (!ValidatePositive(Buzz))
				throw new ArgumentOutOfRangeException("Buzz", "Must be positive.");

			// check that the Start property is less than the Max property
			if (Start >= Max)
				throw new ArgumentException("Start must be less than Max.");

			// check that the Fizz property is less than the Buzz property
			if (Fizz >= Buzz)
				throw new ArgumentException("Fizz must be less than Buzz.");

			// check that the Fizz property is less than the Max property
			if (Fizz >= Max)
				throw new ArgumentException("Fizz must be less than Max.");

			// check that the Buzz property is less than the Max property
			if (Buzz >= Max)
				throw new ArgumentException("Buzz must be less than Max.");

		}

		/// <summary>
		/// True if the given value is a positive integer.
		/// </summary>
		/// <param name="value">The integer to check.</param>
		/// <returns>Boolean</returns>
		private Boolean ValidatePositive(int value)
		{
			return value > 0 ? true : false;
		}

	}

}
