using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeuristicAlgorithms
{
	interface IAlgorithm<T>
	{
		/// <summary>
		/// Function to solve
		/// </summary>
		TestingFunction Function { get; set; }

		/// <summary>
		/// Amount of arguments.
		/// </summary>
		int AmountOfArguments { get; set; }

		/// <summary>
		/// Arguments of type T.
		/// </summary>
		T Arguments { get; }

		/// <summary>
		/// Method searching global minimum using algorithm.
		/// </summary>
		/// <returns>Global minimum</returns>
		double Solve();
	}
}
