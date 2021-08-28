using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzzLibrary
{
	public class FizzBuzzEnumerable : IEnumerable
	{
		private Arguments _arguments;

		public FizzBuzzEnumerable(Arguments arguments)
		{
			_arguments = arguments;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return (IEnumerator)GetEnumerator();
		}
		public FizzBuzzEnumerator GetEnumerator()
		{
			return new FizzBuzzEnumerator(_arguments);
		}
	}


}
