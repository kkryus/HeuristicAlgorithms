using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeuristicAlgorithms.Functions;

namespace HeuristicAlgorithms
{
	class Program
	{
		static void Main(string[] args)
		{
			IAlgorithmStrategy simmulatedAnnealing = new SimmulatedAnnealingAlgorithm(new CircleFunction(), CircleFunction.AmountOfArguments);
			simmulatedAnnealing.Function = new RastriginFunction();
			simmulatedAnnealing.AmountOfArguments = RastriginFunction.AmountOfArguments;

			for (var i = 0; i < 100; i++)
			{
				Console.WriteLine(simmulatedAnnealing.Solve());
			}
			Console.ReadKey();
		}
	}
}
