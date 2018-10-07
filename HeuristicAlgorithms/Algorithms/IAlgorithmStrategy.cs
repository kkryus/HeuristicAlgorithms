using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeuristicAlgorithms
{
	interface IAlgorithmStrategy<T>
	{
		TestingFunction Function { get; set; }
		int AmountOfArguments { get; set; }
		T Arguments { get; }
		double Solve();
	}
}
