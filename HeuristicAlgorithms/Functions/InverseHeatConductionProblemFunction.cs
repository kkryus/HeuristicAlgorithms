using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeuristicAlgorithms.Functions
{
    class InverseHeatConductionProblemFunction : TestingFunction
    {
        public InverseHeatConductionProblemFunction(InverseProblem inverseProblem)
        {
            InverseProblem = inverseProblem;
            Temperature = InverseProblem.Solve();
        }

        public InverseProblem InverseProblem { get; set; }

        public override double LeftBound => -100;

        public override double RightBound => 100;

        public double[][] Temperature { get; set; }

        /// <summary>
        /// p, q, s
        /// </summary>
        public static new int AmountOfArguments => 3;

        public override double Solve(params double[] values)
        {
            double sum = 0;
            double[] measurements = GetTemperatureMeasurements(48);
            for (int i = 0; i < measurements.Length; i++)
            {
                double firstPart = InverseProblem.T * measurements[i] * InverseProblem.tau;
                double secondPart = GetSecondThing(values) * measurements[i] * InverseProblem.tau;
                double together = firstPart - secondPart;
                sum += Math.Pow(together, 2);
            }
            return sum;
        }

        private double GetSecondThing(params double[] values)
        {
            if(values.Length < 3)
            {
                throw new Exception();
            }
            return GetSecondThing(values[0], values[1], values[2]);
        }

        private double GetSecondThing(double p, double q, double s)
        {
            double a = p * -1;
            double b = 1 - q;
            double c = 1.5 - s;
            double delta = (b * b) / (4 * a * c);
            double deltaSqrt = Math.Sqrt(delta);
            double t = deltaSqrt;
            return (p * Math.Pow(t, 2)) + (q * t) + s;
        }

        private double[] GetTemperatureMeasurements(int every)
        {
            int secondIndex = (int)(Temperature[0].Length * 0.8);
            int resultSize = Temperature.Length / every;
            double[] result = new double[resultSize];
            for (int i = 0; i < resultSize; i++)
            {
                result[i] = Temperature[i * every][secondIndex];
            }
            return result;
        }
    }
}
