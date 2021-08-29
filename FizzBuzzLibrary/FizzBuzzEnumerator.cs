using System;
using System.Collections;

namespace FizzBuzzLibrary
{
	/// <summary>
	/// Enumerator object used to itterate thru the range of numbers defined in the arguments.
	/// </summary>
	public class FizzBuzzEnumerator : IEnumerator
	{
		// declare and initialize the _position variable
		private int _position = -1;

		// declare the _arguments variable
		private Arguments _arguments;

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="arguments">Arguments used to construct the FizzBuzzEnumerator.</param>
		public FizzBuzzEnumerator(Arguments arguments)
		{
			_arguments = arguments;
		}

		/// <summary>
		/// Returns true if there are more items in the Enumerator.
		/// </summary>
		/// <returns>Boolean</returns>
		public Boolean MoveNext()
		{
			_position++;
			return _position <= _arguments.Max;
		}

		/// <summary>
		/// Resets the Enumerator.
		/// </summary>
		public void Reset()
		{
			_position = -1;
		}

		object IEnumerator.Current
		{
			get
			{
				return Current;
			}
		}

		/// <summary>
		/// Returns the current item from the Enumerator.
		/// </summary>
		public FizzBuzzNumber Current
		{
			get
			{
				try
				{
					// try to return the newly instanciated FizzBuzzNumber
					return new FizzBuzzNumber(
						_position, 
						_arguments.Fizz, 
						_arguments.Buzz
						);
				}
				catch (IndexOutOfRangeException)
				{
					// throw the exception to the caller
					throw new InvalidOperationException();
				}
			}
		}

	}

}
