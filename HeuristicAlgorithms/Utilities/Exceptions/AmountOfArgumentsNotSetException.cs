using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeuristicAlgorithms.Utilities.Exceptions
{
	public class AmountOfArgumentsNotSetException : Exception
	{
		public AmountOfArgumentsNotSetException()
		{
		}

		public AmountOfArgumentsNotSetException(string message)
			: base(message)
		{
		}

		public AmountOfArgumentsNotSetException(string message, Exception inner)
			: base(message, inner)
		{
		}
	}
}
