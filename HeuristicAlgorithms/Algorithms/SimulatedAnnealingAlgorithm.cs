using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeuristicAlgorithms.Functions;
using HeuristicAlgorithms.Utilities;

namespace HeuristicAlgorithms
{
	public class SimulatedAnnealingAlgorithm : IAlgorithmStrategy<double[]>
	{
		public SimulatedAnnealingAlgorithm(TestingFunction function, int amountOfArguments)
		{
			Function = function;
			AmountOfArguments = amountOfArguments;
			Arguments = new double[amountOfArguments];
		}
		private const double TEMPERATURE = 10000;
		private const double COOLING = 0.001;
		private int amountOfArguments;

		public int AmountOfArguments
		{
			get
			{
				return amountOfArguments;
			}
			set
			{
				amountOfArguments = value;
				Arguments = new double[value];
			}
		}
		public double[] Arguments { get; private set; }
		public TestingFunction Function { get; set; }

		public double Solve()
		{
			DrawVariables();
			double bestSolution = Function.Solve(Arguments);
			double tmpBestSolution = bestSolution;
			double tmpSolution;
			double temperature = TEMPERATURE;
			while (temperature > 0.01)
			{
				DrawVariables();
				tmpSolution = Function.Solve(Arguments);

				if (tmpSolution < bestSolution)
				{
					bestSolution = tmpSolution;
					tmpBestSolution = tmpSolution;
				}
				else if (tmpSolution < tmpBestSolution || ShouldChangeAnyway(tmpBestSolution, tmpSolution, temperature))
				{
					tmpBestSolution = tmpSolution;
				}
				temperature *= 1 - COOLING;
			}
			return bestSolution;
		}

		private void DrawVariables()
		{
			double leftBound = Function.LeftBound;
			double rightBound = Function.RightBound;
			for (int i = 0; i < AmountOfArguments; i++)
			{
				Arguments[i] = RandomGenerator.Instance.GetRandomDoubleInDomain(leftBound, rightBound);
			}
		}

		private bool ShouldChangeAnyway(double tmpBestSolution, double tmpSolution, double temperature)
		{
			return Math.Exp((tmpBestSolution - tmpSolution) / temperature) > RandomGenerator.Instance.NextDouble();
		}
	}
}
