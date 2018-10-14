using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeuristicAlgorithms.Functions
{
	class EasomFunction : TestingFunction
	{
		public override double LeftBound => -10;

		public override double RightBound => 10;
		public static new int AmountOfArguments => 2;

		public override double Solve(params double[] values)
		{
			return -Math.Cos(values[0]) * Math.Cos(values[1]) * Math.Exp(-((values[0] * Math.PI)* (values[0] * Math.PI)) - ((values[1] - Math.PI)* (values[1] - Math.PI)));
		}
	}
}
