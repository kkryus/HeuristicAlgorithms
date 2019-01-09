using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeuristicAlgorithms.Utilities;

namespace HeuristicAlgorithms.Functions
{
	public class RastriginFunction : TestingFunction
	{
		private const double A = 10;

		public override double LeftBound => -5.12;
		public override double RightBound => 5.12;
		public static new int AmountOfArguments => 5;// RandomGenerator.Instance.GetRandomIntInDomain(0, 10);

		public override double Solve(params double[] values)
		{
			double result = A * values.Length;
			for (int i = 0; i < values.Length; i++)
			{
				result += GetValueInStep(values[i]);
			}
			return result;
		}

		//https://arxiv.org/pdf/1207.4318.pdf
		private double GetValueInStep(double value)
		{
			return ((value * value) - (A * Math.Cos(2 * Math.PI * value)));// ValidateDomain(value) ? ((value * value) - (A * Math.Cos(2 * Math.PI * value))) : A * value * value;
		}

		private bool ValidateDomain(double value)
		{
			return value >= -5.12 && value <= 5.12;
		}
	}
}
