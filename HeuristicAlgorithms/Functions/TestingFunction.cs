using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeuristicAlgorithms.Utilities;
using HeuristicAlgorithms.Utilities.Exceptions;

namespace HeuristicAlgorithms
{
	public abstract class TestingFunction
	{
		public abstract double LeftBound { get; }
		public abstract double RightBound { get; }
		public static int AmountOfArguments => throw new AmountOfArgumentsNotSetException(Resources.AmountOfArgumentsNotSetMessage);
		public abstract double Solve(params double[] values);
	}
}
