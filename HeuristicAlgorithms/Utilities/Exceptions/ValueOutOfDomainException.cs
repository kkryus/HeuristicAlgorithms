using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeuristicAlgorithms.Utilities.Exceptions
{
	public class ValueOutOfDomainException : Exception
	{
		public ValueOutOfDomainException()
		{
		}

		public ValueOutOfDomainException(string message)
			: base(message)
		{
		}

		public ValueOutOfDomainException(string message, Exception inner)
			: base(message, inner)
		{
		}
	}
}
