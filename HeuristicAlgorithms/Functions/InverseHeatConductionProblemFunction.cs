using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeuristicAlgorithms.Functions
{
    class InverseHeatConductionProblemFunction : TestingFunction
    {
        public InverseHeatConductionProblemFunction(DirectProblem inverseProblem)
        {
            InverseProblem = inverseProblem;
            Temperature = InverseProblem.Solve();
        }

        public DirectProblem InverseProblem { get; set; }

        public override double LeftBound => -100;

        public override double RightBound => 100;

        public double[][] Temperature { get; set; }

        public double p, q, s;

        private int everyXMeasurement = 48;

        /// <summary>
        /// p, q, s
        /// </summary>
        public static new int AmountOfArguments => 3;

        public override double Solve(params double[] values)
        {
            double sum = 0;
            double[] measurements = GetTemperatureMeasurements(everyXMeasurement);
            for (int i = 0; i < measurements.Length; i++)
            {
                double firstPart = InverseProblem.T * measurements[i] * (i*InverseProblem.tau);
                //double secondPart = GetSecondThing(i, values) * measurements[i] * InverseProblem.tau;
                double secondPart = GetSecondThing(values[0], values[1], values[2], i) * measurements[i] * (i*InverseProblem.tau);
                double together = firstPart - secondPart;
                sum += Math.Pow(together, 2);
            }
            if(sum < 0.001)
            {
                ;
            }
            return sum;
        }

        private double GetSecondThing(int iterator, params double[] values)
        {
            //p,q,s
            if (values.Length < 3)
            {
                throw new Exception();
            }
            return GetSecondThing(values[0], values[1], values[2], iterator);
        }

        private double GetSecondThing(double p, double q, double s, int i)
        {
            double t = ( everyXMeasurement * i) * InverseProblem.tau;

            this.p = p;
            this.q = q;
            this.s = s;          
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
