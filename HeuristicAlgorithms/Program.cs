using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeuristicAlgorithms.Functions;
using HeuristicAlgorithms.Models;
using System.IO;

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
				//IAlgorithm<double[]> simulatedAnnealing;
				SimulatedAnnealingAlgorithm simulatedAnnealing;
				if (circle)
				{
					simulatedAnnealing = new SimulatedAnnealingAlgorithm(new CircleFunction(), CircleFunction.AmountOfArguments);
					//simulatedAnnealing = new SimulatedAnnealingAlgorithm(new EasomFunction(), EasomFunction.AmountOfArguments);
				}
				else
				{
					simulatedAnnealing = new SimulatedAnnealingAlgorithm(new RastriginFunction(), RastriginFunction.AmountOfArguments);
				}
				var cooling = simulatedAnnealing.GetCoolingArray();
				var temp = simulatedAnnealing.GetBeginingTemperatureArray();
				var ending = simulatedAnnealing.GetEndingTemperatureArray();
				var iterations = simulatedAnnealing.GetIterationsArray();
				List<AnnealingTestingModel> lista = new List<AnnealingTestingModel>();
				/*for(int i = 0; i < temp.Length; i++)
				{
					//for(int j = 0; j < ending.Length; j++)
					//{
						for(int k = 0; k < cooling.Length; k++)
						{
							for (int n = 0; n < iterations.Length; n++)
							{	*/
				//lista.Add(simulatedAnnealing.Solve2(temp[i], iterations[n], cooling[k]));
				//	}
				//	}
				//}
				//}
				lista.Add(simulatedAnnealing.Solve2(2250, 1500, 0.96));
				//tutaj stawiajac breakpoint's mozna przy debugowaniu zobaczyc wynik
				lista = lista.OrderBy(x => x.bestSolution).ToList();
				#region Zapisywanie do pliku testow, zakomentowane
				/*for(int i = 0; i < lista.Count; i++)
				{
					File.AppendAllText(@"e:\bestSolution5.txt", 
						"best solution: " + lista[i].bestSolution +
						"|tmpbestsolution: " + lista[i].tmpBestSolution +
						"|beginingTemperature: " + lista[i].beginingTemperature +
						"|endingTemperature: " + lista[i].endingTemperature +
						"|cooling: " + lista[i].cooling +
						"|iterations: " + lista[i].iterations +
						Environment.NewLine);
				}

				lista = lista.OrderBy(x => x.tmpBestSolution).ToList();
				for (int i = 0; i < lista.Count; i++)
				{
					File.AppendAllText(@"e:\tmpBestSolution5.txt",
						"best solution: " + lista[i].bestSolution +
						"|tmpbestsolution: " + lista[i].tmpBestSolution +
						"|beginingTemperature: " + lista[i].beginingTemperature +
						"|endingTemperature: " + lista[i].endingTemperature +
						"|cooling: " + lista[i].cooling +
						"|iterations: " + lista[i].iterations +
						Environment.NewLine);
				}
				*/
				#endregion
				//for(int i = 0; i < 5; i++)
				//{
				//simulatedAnnealing.Solve();
				//}
				//double elapsedMs = 0;
				/*for (var i = 0; i < 100; i++)
				{
					var watch = System.Diagnostics.Stopwatch.StartNew();					
					//Console.WriteLine();
					simulatedAnnealing.Solve();
					watch.Stop();
					elapsedMs += watch.ElapsedMilliseconds;
				}*/
				//elapsedMs /= 100;
				//string oko = "";
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
