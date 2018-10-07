using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeuristicAlgorithms.Functions;
using HeuristicAlgorithms.Utilities;
using HeuristicAlgorithms.Models;
using System.ComponentModel;

namespace HeuristicAlgorithms
{
	public class FireflyAlgorithm : IAlgorithmStrategy<FireflyModel[]>
	{
		private int amountOfArguments;
		private int someLimit = 100000;

		public TestingFunction Function { get; set; }
		public int AmountOfArguments
		{
			get
			{
				return amountOfArguments;
			}
			set
			{
				amountOfArguments = value;
				Arguments = new FireflyModel[Int32.Parse(Resources.Fireflies)];
				//Arguments = new double[Int32.Parse(Resources.Fireflies)][];
				PrepareArguments(value);
			}
		}

		public FireflyModel[] Arguments { get; private set; }

		public double Solve()
		{
			DrawVariables();
			WriteValues();
			Console.WriteLine("-----------------------------------------");
			for (int repeats = 0; repeats < someLimit; repeats++)
			{
				for (int i = 0; i < Arguments.GetLength(0); i++)
				{
					Arguments[i].Value = Function.Solve(Arguments[i].Variables);
					for (int j = 0; j < Arguments[i].Variables.GetLength(0); j++)
					{
						Arguments[j].Value = Function.Solve(Arguments[j].Variables);
						if (i != j && Arguments[j].Value < Arguments[i].Value)
						{
							MoveWorseFirefly(Arguments[i].Variables, Arguments[j].Variables);
							//Rij
							//double distance = outerResult - innerResult;
						}
					}
				}
				Arguments.OrderBy(x => x.Value);
			}
			WriteValues();
			Console.Write("end");/**/
			return 5;// Function.Solve(1, 1);
		}

		private void MoveWorseFirefly(double[] better, double[] worse)
		{
			//same amount of variables
			for(int i = 0; i < better.GetLength(0); i++)
			{
				if(better[i] > worse[i])
				{
					worse[i] += RandomGenerator.Instance.GetSmallDouble();
				}
				else
				{
					worse[i] -= RandomGenerator.Instance.GetSmallDouble();
				}
			}
		}

		private void PrepareArguments(int value)
		{
			for (int i = 0; i < Arguments.Length; i++)
			{
				Arguments[i] = new FireflyModel(value);
			}
		}

		private void WriteValues()
		{
			for (int i = 0; i < Arguments.GetLength(0); i++)
			{
				for (int j = 0; j < Arguments[i].Variables.GetLength(0); j++)
				{
					Console.Write(Arguments[i].Variables[j] + "|");
				}
				Console.WriteLine();
			}/**/
		}

		private void DrawVariables()
		{
			double leftBound = Function.LeftBound;
			double rightBound = Function.RightBound;
			for (int i = 0; i < Arguments.GetLength(0); i++)
			{
				for (int j = 0; j < Arguments[i].Variables.GetLength(0); j++)
				{
					Arguments[i].Variables[j] = RandomGenerator.Instance.GetRandomDoubleInDomain(leftBound, rightBound);
				}
			}/**/
		}
	}
}
