using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeuristicAlgorithms
{
	interface IAlgorithmStrategy
	{
		TestingFunction Function { get; set; }
		int AmountOfArguments { get; set; }
		double[] Arguments { get; }
		double Solve();
	}
}
