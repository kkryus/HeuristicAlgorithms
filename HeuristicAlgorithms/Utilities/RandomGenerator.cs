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

		/// <summary>
		/// Returns random double value in domain.
		/// </summary>
		/// <param name="leftBound">Left side of domain.</param>
		/// <param name="rightBound">Right side of domain.</param>
		/// <returns>Random double in domain</returns>
		public double GetRandomDoubleInDomain(double leftBound, double rightBound)
		{
			return random.NextDouble() * (rightBound - leftBound) + leftBound;
		}

		/// <summary>
		/// Returns random integer value in domain.
		/// </summary>
		/// <param name="leftBound">Left side of domain.</param>
		/// <param name="rightBound">Right side of domain.</param>
		/// <returns>Random integer in domain</returns>
		public int GetRandomIntInDomain(int leftBound, int rightBound)
		{
			var foo = random.Next(leftBound, rightBound);
			//Console.WriteLine(foo);
			return foo;
		}

		/// <summary>
		/// Returns random double in [0.00001, 0.00099]
		/// </summary>
		/// <returns>Random small double</returns>
		public double GetSmallDouble()
		{
			//random double could be 0
			double result = random.NextDouble();
			return result > 0 ? result / 1000 : 0.00001;
		}

		/// <summary>
		/// Returns random double in [0,1].
		/// </summary>
		/// <returns>Random double number</returns>
		public double NextDouble()
		{
			return random.NextDouble();
		}
	}
}
