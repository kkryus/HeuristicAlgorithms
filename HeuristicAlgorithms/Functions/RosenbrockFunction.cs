using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeuristicAlgorithms.Functions
{
    class RosenbrockFunction : TestingFunction
    {
        public override double LeftBound => -Double.MaxValue;

        public override double RightBound => Double.MaxValue;

        public override double Solve(params double[] values)
        {
            double result = 0;
            for(int i = 0; i < values.Length-1; i++)
            {
                result += ((100 * ((values[i + 1] - (values[i] * values[i])) * (values[i + 1] - (values[i] * values[i])))) + ((1 - values[i]) * (1 - values[i])));
            }
            return result;
        }
    }
}
