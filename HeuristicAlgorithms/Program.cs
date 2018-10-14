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
			bool algorithm = true;
			bool circle = !true;
			if (algorithm)
			{
				IAlgorithm<double[]> simulatedAnnealing;
				if (circle)
				{
					simulatedAnnealing = new SimulatedAnnealingAlgorithm(new CircleFunction(), CircleFunction.AmountOfArguments);
					//simulatedAnnealing = new SimulatedAnnealingAlgorithm(new EasomFunction(), EasomFunction.AmountOfArguments);
				}
				else
				{
					simulatedAnnealing = new SimulatedAnnealingAlgorithm(new RastriginFunction(), RastriginFunction.AmountOfArguments);
				}				

				for (var i = 0; i < 100; i++)
				{
					Console.WriteLine(simulatedAnnealing.Solve());
				}
			}
			else
			{
				IAlgorithm<FireflyModel[]> firefly = new FireflyAlgorithm();
				if (circle)
				{
					firefly.AmountOfArguments = 2;
					firefly.Function = new CircleFunction();
					firefly.Solve();
				}
				else
				{

				}
				
			}

			Console.ReadKey();
		}
	}
}
