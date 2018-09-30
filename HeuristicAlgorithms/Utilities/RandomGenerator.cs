using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeuristicAlgorithms.Utilities
{
	public class RandomGenerator
	{
		#region SingletonImplementation
		private RandomGenerator()
		{

		}
		private static RandomGenerator instance;
		public static RandomGenerator Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new RandomGenerator();
				}
				return instance;
			}
		}
		#endregion
		private Random random = new Random();

		public double GetRandomDoubleInDomain(double leftBound, double rightBound)
		{
			return random.NextDouble() * (rightBound - leftBound) + leftBound;
		}

		public int GetRandomIntInDomain(int leftBound, int rightBound)
		{
			return random.Next(leftBound, rightBound);
		}

		public double NextDouble()
		{
			return random.NextDouble();
		}
	}
}
