using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeuristicAlgorithms.Functions;

namespace HeuristicAlgorithms
{
	public class FireflyAlgorithm : IAlgorithmStrategy
	{
		public TestingFunction Function { get; set; }
		public int AmountOfArguments
		{
			get
			{
				return AmountOfArguments;
			}
			set
			{
				AmountOfArguments = value;
				Arguments = new double[value];
			}
		}
		public double[] Arguments { get; private set; }

		public double Solve()
		{
			return Function.Solve(1, 1);
		}
	}
}
