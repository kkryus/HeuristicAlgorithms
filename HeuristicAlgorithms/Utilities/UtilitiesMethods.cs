using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeuristicAlgorithms.Utilities
{
    class UtilitiesMethods
    {
        public double f(double x)
        {
            return 0.5*(x * x) + 0.5;
        }
        public double g(double t)
        {
            return t + 0.5;
        }
        public double h(double t)
        {
            return t + 1;
        }
    }
}
