using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeuristicAlgorithms.Functions;
using HeuristicAlgorithms.Utilities;
using System.IO;
using HeuristicAlgorithms.Models;

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

		private int maxCounter = 0;

		/// <summary>
		/// Constant temperature which will be cooled.
		/// </summary>
		/// //https://pdfs.semanticscholar.org/b145/faf936fbb2c1c6f8530a20dbe3c8538aedbf.pdf
		private const double TEMPERATURE = 100;

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

		#region Nie uzywane na razie
		/// <summary>
		/// Method searches global minimum using Simulated Annealing algorithm.
		/// </summary>
		/// <returns>Global minimum</returns>
		public double Solve()
		{
			//Obecnie działam na metodzie Solve2, gdyz ta metoda jest dziedziczona z interfejsu i nie moge tak latwo zmienic typu zwracanego
			return 5;

			/*DrawArguments();
			double bestSolution = Function.Solve(Arguments);
			double tmpBestSolution = Function.Solve(Arguments);
			double tmpSolution;
			double temperature = TEMPERATURE;
			while (temperature > 0.01)
			{
				for (int i = 0; i < 150; i++)
				{
					Move(5, 5);
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
					else if (ShouldChangeAnyway(tmpSolution - tmpBestSolution, temperature, 5))
					{
						tmpBestSolution = tmpSolution;
						CopyValues();
					}
					//File.AppendAllText(@"e:\file.txt", tmpBestSolution + Environment.NewLine);
				}
				temperature *= COOLING;
			}
			return bestSolution;*/
		}
		#endregion


		public AnnealingTestingModel Solve2(double beginingTemperature, double endingTemperature, int iterations, double cooling)
		{
			//Obliczanie maxCountera
			{
                maxCounter = 0;
				double tmpTemperature = beginingTemperature;
				while (tmpTemperature > endingTemperature)
				{
					tmpTemperature *= cooling;
					maxCounter++;
				}
			}

			#region Sumaryczne wartosci wynikowe
			double best = 0;
			double temp = 0;
			double tempbest = 0;
			#endregion
			#region Poczatkowe wartosci musze zainicjowac, aby na samym dole ich uzywac, a wysoka liczba i tak bedzie zmniejszona poprzez wywolanie funkcji
			double bestSolution = 10000000000;
			double tmpBestSolution = 1000000000000;
			double tmpSolution = 100000;
			#endregion
			int repetitions = 10;
			//Licznik ile razy dana temperatura sie zmniejszy az osiagnie wartosc minimalna
			int counter = 0;
			//zeby wynik byl w miare pewny, powtarzam dzialanie pewna ilosc razy sumujac wyniki, a nastepnie dzielac przez ilosc powtorzen
			for (int k = 0; k < repetitions; k++)
			{
				//Losuje poczatkowe argumenty dla tablicy Arguments				
				DrawArguments();
				bestSolution = Function.Solve(Arguments);
				tmpBestSolution = Function.Solve(Arguments);
				tmpSolution = Function.Solve(Arguments);

				//Dla kazdego nowego powtorzenia zaczynam od poczatkowej, wysokiej temperatury
				double temperature = beginingTemperature;
				while (temperature > endingTemperature)
				{
					for (int i = 0; i < iterations; i++)
					{
						//Wykonuje pewien losowy ruch argumentow
						//Wybiera sasiadow z tablicy Arguments do tablicy Arguments2
						Move(counter, temperature);
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
						//Funkcja prawdopodobienstwa, nawet jezeli wynik jest gorszy, to z pewnym prawdopodobienstwem je zamieni
						else if (ShouldChangeAnyway(tmpBestSolution - tmpSolution, temperature, counter))
						{
							tmpBestSolution = tmpSolution;
							CopyValues();
						}
					}
					temperature *= cooling;
					counter++;
				}
				best += bestSolution;
				temp += tmpSolution;
				tempbest += tmpBestSolution;
				counter = 0;
			}
			return new AnnealingTestingModel()
			{
				beginingTemperature = beginingTemperature,
				endingTemperature = endingTemperature,
				iterations = iterations,
				cooling = cooling,
				bestSolution = best / repetitions,
				tmpBestSolution = tempbest / repetitions,
				tmpSolution = temp / repetitions
			};
			//return bestSolution;
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
		private void Move(int counter, double temperature)
		{
			for (int i = 0; i < AmountOfArguments; i++)
			{
				//tyle razy jeszcze temperatura zostanie schlodzona
				double leftTemperatureCoolingTimes = maxCounter - counter;
				//to co wyzej, tylko w procentach
				double leftPercent = leftTemperatureCoolingTimes / maxCounter;

                //144,6 jest maksymalna wartoscia dla rastrigina o 5 wymiarach
                //nie wiem dlaczego przy 100 dawalo to mniej wiecej najlepsze wyniki
                double value = (0.8 * 10.24) * (leftPercent);

                //warunki by nie wybierac wartosci poza zakresem, na razie na sztywno
                if (value < -5.12)
                {
                    value = -5.12;
                }
                if (value > 5.12)
                {
                    value = 5.12;
                }

                //losowa liczba w zakresie jak podano
                double v = RandomGenerator.Instance.GetRandomDoubleInDomain(-value, value);

                //to wydaje sie dzialac nieco gorzej
                //double v = RandomGenerator.Instance.GetRandomDoubleInDomain(-1, 1);
                double newValue = Arguments[i] + v;// * temperature;

				
				Arguments2[i] = newValue;



				//poprzedni sposob wybierania sasiada
				//double value = 1;
				//double lower = Arguments[i] - value < Function.LeftBound ? Function.LeftBound : Arguments[i] - value;
				//double upper = Arguments[i] + value > Function.RightBound ? Function.RightBound : Arguments[i] + value;
				//Arguments2[i] = RandomGenerator.Instance.GetRandomDoubleInDomain(lower, upper);
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
		private bool ShouldChangeAnyway(double distance, double temperature, double counter)
		{
			var first = Math.Exp((distance / temperature));
			return first >= RandomGenerator.Instance.NextDouble();
		}

		#region Comment
		/*if (temperature < 0.1)
				{
					value = 0.001;
				}*/
		//int foobar = RandomGenerator.Instance.GetRandomIntInDomain(0, Arguments.Length);
		//else 
		/*if (temperature < 0.1)
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

		//random > 0.5 ? Arguments[foobar] + smallRandom / divideFactor : Arguments[foobar] - smallRandom / divideFactor;//RandomGenerator.Instance.GetRandomDoubleInDomain(leftBound, rightBound);
		/*if (Arguments[foobar] > Function.RightBound)
		{
			Arguments[foobar] -= 2 * (smallRandom / divideFactor);
		}
		else if (Arguments[foobar] < Function.LeftBound)
		{
			Arguments[foobar] += 2 * (smallRandom / divideFactor);
		}*/

		//double random = RandomGenerator.Instance.NextDouble();
		//double smallRandom = RandomGenerator.Instance.NextDouble();// RandomGenerator.Instance.GetSmallDouble();
		#endregion

		//500-5000?
		//drop = 500?
		// ->20?
		public double[] GetBeginingTemperatureArray()
		{
			int arraySize = 8;
			double beginingValue = 4001;
			double dropValue = 500;
			double[] beginingTemperatureArray = new double[arraySize];
			for (int i = 0; i < arraySize; i++)
			{
				beginingTemperatureArray[i] = beginingValue;
				beginingValue -= dropValue;
			}
			return beginingTemperatureArray;
		}
		//0.1 - 0.001 min
		// 0.01?
		// - > 11x?
		public double[] GetEndingTemperatureArray()
		{
			int arraySize = 11;
			double beginingValue = 0.101;
			double dropValue = 0.01;
			double[] endingTemperatureArray = new double[arraySize];
			for (int i = 0; i < arraySize; i++)
			{
				endingTemperatureArray[i] = beginingValue;
				beginingValue -= dropValue;
			}
			return endingTemperatureArray;
		}
		//0.91 - 0.99
		//every 2nd
		// -> 10
		public double[] GetCoolingArray()
		{
			int arraySize = 5;
			double beginingValue = 0.91;
			double riseValue = 0.02;
			double[] coolingArray = new double[arraySize];
			for (int i = 0; i < arraySize; i++)
			{
				coolingArray[i] = beginingValue;
				beginingValue += riseValue;
			}
			return coolingArray;
		}
		//100 - 3000
		//every 250?
		// -> 15?
		public int[] GetIterationsArray()
		{
			int arraySize = 13;
			int beginingValue = 100;
			int riseValue = 250;
			int[] iterationsArray = new int[arraySize];
			for (int i = 0; i < arraySize; i++)
			{
				iterationsArray[i] = beginingValue;
				beginingValue += riseValue;
			}
			return iterationsArray;
		}



	}
}
