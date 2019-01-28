using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeuristicAlgorithms.Functions
{
    class RosenbrockFunction : TestingFunction
    {
        public override double LeftBound => -10;

        public override double RightBound => 10;

        public static new int AmountOfArguments => 3;// RandomGenerator.Instance.GetRandomIntInDomain(0, 10);

        public override double Solution => 0;

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
