using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeuristicAlgorithms.Models
{
	public class FireflyModel
	{
		public FireflyModel(int amountOfArguments)
		{
			Variables = new double[amountOfArguments];
		}
		public double[] Variables { get; set; }
		public double Value { get; set; }
	}
}
