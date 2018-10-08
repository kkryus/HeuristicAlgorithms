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
		private double alpha = 0.3;
		private double rand = 0.4;
		private double beta0 = 1;
		//beta(r) -> what for?

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
				//The initial population of fireflies is generated in the following
				//form:	xi = LB + rand · (UB − LB)
				Arguments = new FireflyModel[Int32.Parse(Resources.Fireflies)];
				//Arguments = new double[Int32.Parse(Resources.Fireflies)][];
				PrepareArguments(value);
			}
		}

		public FireflyModel[] Arguments { get; private set; }

		//https://pdfs.semanticscholar.org/704a/4ca7d6039e65b6e764e82476431f75705f53.pdf
		//http://fluid.ippt.gov.pl/bulletin/(60-2)363.pdf
		public double Solve()
		{
			DrawVariables();
			SetLightIntensity();
			//Console.WriteLine(GetDistance(Arguments[0], Arguments[1]));

			Console.WriteLine("-----------------------------------------");
			for (int repeats = 0; repeats < someLimit; repeats++)
			{
				for (int i = 0; i < Arguments.GetLength(0); i++)
				{
					for (int j = 0; j < Arguments[i].Variables.GetLength(0); j++)
					{
						if (i != j && Arguments[j].Value > Arguments[i].Value)
						{
							//xi = xi + β0e−γr2ij(xj − xi) + α(rand − 1/2), 
							//beta0 ? -> most cases its 1
							//gamma? -> in most cases varies from 0,01 to 100
							//rij^2?
							//xj - xi?
							//alfa? -> most cases its [0,1]
							//rand - 1/2 -> rand is uniformly distributed rand [0,1]
							//Rij
							//double distance = outerResult - innerResult;
						}
						//obtain attractiveness
						//find new solutions and update light intensity
						SetLightIntensity();
					}
				}
			}/**/
			 //WriteValues();
			Console.Write("end");/**/
			return 5;// Function.Solve(1, 1);
		}

		private double GetDistance(FireflyModel xi, FireflyModel xj)
		{
			return Math.Sqrt(Enumerable.Zip(xi.Variables, xj.Variables, (xiVariable, xjVariable) => (xiVariable - xjVariable) * (xiVariable - xjVariable)).Sum());
		}

		private void SetLightIntensity()
		{
			for (int i = 0; i < Arguments.Length; i++)
			{
				Arguments[i].Value = Function.Solve(Arguments[i].Variables);
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
