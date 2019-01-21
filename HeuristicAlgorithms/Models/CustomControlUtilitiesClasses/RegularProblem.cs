using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeuristicAlgorithms.Models.CustomControlUtilitiesClasses
{
    public class RegularProblem
    {
        public RegularProblem(string problem, bool hasDimensions, int defaultDimensions)
        {
            Problem = problem;
            HasDimensions = hasDimensions;
            DefaultDimensions = defaultDimensions;
        }
        public string Problem { get; set; }

        public bool HasDimensions { get; set; }

        public int DefaultDimensions { get; set; }
    }
}
