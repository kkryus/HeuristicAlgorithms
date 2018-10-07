using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeuristicAlgorithms.Functions;
using HeuristicAlgorithms.Models;

namespace HeuristicAlgorithms
{
	class Program
	{
		static void Main(string[] args)
		{
			/*IAlgorithmStrategy<double[]> simulatedAnnealing = new SimulatedAnnealingAlgorithm(new CircleFunction(), CircleFunction.AmountOfArguments);
			simulatedAnnealing.Function = new RastriginFunction();
			simulatedAnnealing.AmountOfArguments = RastriginFunction.AmountOfArguments;

			for (var i = 0; i < 100; i++)
			{
				Console.WriteLine(simulatedAnnealing.Solve());
			}*/
			IAlgorithmStrategy<FireflyModel[]> firefly = new FireflyAlgorithm();
			firefly.AmountOfArguments = 2;
			firefly.Function = new CircleFunction();
			firefly.Solve();
			Console.ReadKey();
		}
	}
}
