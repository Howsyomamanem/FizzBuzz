using System.Collections;

namespace FizzBuzzLibrary
{
	/// <summary>
	/// Enumerable object used to itterate thru the range of number defined in the arguments.
	/// </summary>
	public class FizzBuzzEnumerable : IEnumerable
	{
		// declare the _arguments variable
		private Arguments _arguments;

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="arguments">The Arguments used to define the itteration.</param>
		public FizzBuzzEnumerable(Arguments arguments)
		{
			_arguments = arguments;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return (IEnumerator)GetEnumerator();
		}
		/// <summary>
		/// Returns the Enumerator.
		/// </summary>
		/// <returns>FizzBuzzEnumerator</returns>
		public FizzBuzzEnumerator GetEnumerator()
		{
			// return the FizzBuzzEnumerator with the given Arguments
			return new FizzBuzzEnumerator(_arguments);
		}
	}


}
