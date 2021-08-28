using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzzLibrary
{
	public class FizzBuzzEnumerator : IEnumerator
	{
		private int _position = -1;

		private Arguments _arguments;

		public FizzBuzzEnumerator(Arguments arguments)
		{
			_arguments = arguments;
		}

		public Boolean MoveNext()
		{
			_position++;
			return _position <= _arguments.Max;
		}

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

		public FizzBuzzNumber Current
		{
			get
			{
				try
				{
					return new FizzBuzzNumber(
						_position, 
						_arguments.Fizz, 
						_arguments.Buzz
						);
				}
				catch (IndexOutOfRangeException)
				{
					throw new InvalidOperationException();
				}
			}
		}

	}

}
