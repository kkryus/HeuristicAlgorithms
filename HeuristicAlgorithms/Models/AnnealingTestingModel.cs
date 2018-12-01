using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeuristicAlgorithms.Models
{
	public struct AnnealingTestingModel
	{
		public double bestSolution;
		public double tmpSolution;
		public double tmpBestSolution;
		public int iterations;
		public double beginingTemperature;
		public double cooling;
		public double endingTemperature;
	}
}
