using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeuristicAlgorithms.Utilities;
using HeuristicAlgorithms.Utilities.Exceptions;

namespace HeuristicAlgorithms.Functions
{
	public class CircleFunction : TestingFunction
	{
		public override double LeftBound => -10;
		public override double RightBound => 10;
		public static new int AmountOfArguments => Int32.Parse(Resources.CircleFunctionArguments);

		public override double Solve(params double[] values)
		{
			//if (!ValidateDomain(values))
			//{
			//	throw new ValueOutOfDomainException(Resources.ValueOutOfDomainMessage);
			//}
			return (values[0] * values[0]) + (values[1] * values[1]);
		}

		private bool ValidateDomain(params double[] values)
		{
			return values.Length >= Int32.Parse(Resources.CircleFunctionArguments) && (values[0] >= LeftBound && values[0] <= RightBound) && (values[1] >= LeftBound && values[1] <= RightBound);
		}
	}
}
