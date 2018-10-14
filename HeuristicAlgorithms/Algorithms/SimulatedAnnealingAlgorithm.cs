using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeuristicAlgorithms.Functions;
using HeuristicAlgorithms.Utilities;
using System.IO;

namespace HeuristicAlgorithms
{
	public class SimulatedAnnealingAlgorithm : IAlgorithm<double[]>
	{
		public SimulatedAnnealingAlgorithm(TestingFunction function, int amountOfArguments)
		{
			Function = function;
			AmountOfArguments = amountOfArguments;
			Arguments = new double[amountOfArguments];
			Arguments2 = new double[amountOfArguments];
		}

		/// <summary>
		/// Constant temperature which will be cooled.
		/// </summary>
		/// //https://pdfs.semanticscholar.org/b145/faf936fbb2c1c6f8530a20dbe3c8538aedbf.pdf
		private const double TEMPERATURE = 250;

		/// <summary>
		/// Temperature will be subtracted by this value every iteration.
		/// </summary>
		private const double COOLING = 0.99;
		private int amountOfArguments;

		/// <summary>
		/// Amount of arguments.
		/// </summary>
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
				Arguments2 = new double[value];
			}
		}

		/// <summary>
		/// Arguments for the Function.
		/// </summary>
		public double[] Arguments { get; private set; }

		public double[] Arguments2 { get; private set; }

		/// <summary>
		/// Function where global minimum will be searched.
		/// </summary>
		public TestingFunction Function { get; set; }

		/// <summary>
		/// Method searches global minimum using Simulated Annealing algorithm.
		/// </summary>
		/// <returns>Global minimum</returns>
		public double Solve()
		{
			DrawArguments();
			double bestSolution = Function.Solve(Arguments);
			double tmpBestSolution = Function.Solve(Arguments);
			double tmpSolution;
			double temperature = TEMPERATURE;
			while (temperature > 0.0001)
			{
				for (int i = 0; i < 450; i++)
				{
					Move(temperature);
					tmpSolution = Function.Solve(Arguments2);
					if (tmpSolution < bestSolution)
					{
						bestSolution = tmpSolution;
					}
					if (tmpSolution < tmpBestSolution)
					{
						tmpBestSolution = tmpSolution;
						CopyValues();
					}
					else if (ShouldChangeAnyway(tmpSolution - tmpBestSolution, temperature))
					{
						tmpBestSolution = tmpSolution;
						CopyValues();
					}
					//File.AppendAllText(@"e:\file.txt", tmpBestSolution + Environment.NewLine);
				}
				temperature *= COOLING;
			}
			return bestSolution;
		}


		/// <summary>
		/// Draws arguments.
		/// </summary>
		private void DrawArguments()
		{
			double leftBound = Function.LeftBound;
			double rightBound = Function.RightBound;
			for (int i = 0; i < AmountOfArguments; i++)
			{
				Arguments[i] = RandomGenerator.Instance.GetRandomDoubleInDomain(leftBound, rightBound);
			}
		}

		/// <summary>
		/// Moves arguments randomly a bit.
		/// </summary>
		private void Move(double temperature)
		{
			for (int i = 0; i < AmountOfArguments; i++)
			{
				//double random = RandomGenerator.Instance.NextDouble();
				//double smallRandom = RandomGenerator.Instance.NextDouble();// RandomGenerator.Instance.GetSmallDouble();
				double value = 1;
				/*if (temperature < 0.1)
				{
					value = 0.001;
				}*/
				//int foobar = RandomGenerator.Instance.GetRandomIntInDomain(0, Arguments.Length);
				//else 
				if (temperature < 0.1)
				{
					value = 0.05;
					//int divideFactor = 10;
				}
				else if(temperature < 0.3)
				{
					value = 0.1;
				}
				else 
				if (temperature < 0.75)
				{
					value = 0.5;
				}/**/
				double lower = Arguments[i] - value < Function.LeftBound ? Function.LeftBound : Arguments[i] - value;
				double upper = Arguments[i] + value > Function.RightBound ? Function.RightBound : Arguments[i] + value;

				Arguments2[i] = RandomGenerator.Instance.GetRandomDoubleInDomain(lower, upper);//random > 0.5 ? Arguments[foobar] + smallRandom / divideFactor : Arguments[foobar] - smallRandom / divideFactor;//RandomGenerator.Instance.GetRandomDoubleInDomain(leftBound, rightBound);
																							   /*if (Arguments[foobar] > Function.RightBound)
																							   {
																								   Arguments[foobar] -= 2 * (smallRandom / divideFactor);
																							   }
																							   else if (Arguments[foobar] < Function.LeftBound)
																							   {
																								   Arguments[foobar] += 2 * (smallRandom / divideFactor);
																							   }*/
			}
		}

		private void CopyValues()
		{
			for (int i = 0; i < AmountOfArguments; i++)
			{
				Arguments[i] = Arguments2[i];
			}
		}

		/// <summary>
		/// Checks if solution should change altough it's not best.
		/// </summary>
		/// <param name="tmpBestSolution">Best solution so far</param>
		/// <param name="tmpSolution">Solution of temporary arguments</param>
		/// <param name="temperature">Current temperature</param>
		/// <returns>If solution should change</returns>
		private bool ShouldChangeAnyway(double distance, double temperature)
		{
			var first = Math.Exp(-(distance / temperature));

			//File.AppendAllText(@"e:\file.txt", first + Environment.NewLine);
			return first >= RandomGenerator.Instance.NextDouble();
		}
	}
}
