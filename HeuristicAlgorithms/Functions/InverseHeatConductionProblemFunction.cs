using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeuristicAlgorithms.Functions
{
    class InverseHeatConductionProblemFunction : TestingFunction
    {
        public InverseHeatConductionProblemFunction(DirectProblem directProblem)
        {
            DirectProblem = directProblem;
            Temperature = DirectProblem.Solve();
            Measurements = GetDirectProblemTemperatureMeasurements(everyXMeasurement);
            InverseProblem = new DirectProblem(directProblem.f, directProblem.g, GetSecondThing2, directProblem.a, directProblem.T, directProblem.nx, directProblem.nt, directProblem.c, directProblem.rho, directProblem.lambda);
        }

        public DirectProblem DirectProblem { get; set; }
        public DirectProblem InverseProblem { get; private set; }

        public override double LeftBound => -10;

        public override double RightBound => 10;

        public double[][] Temperature { get; set; }

        public double[] Measurements { get; set; }

        public int SecondIndex { get; set; }
        public int ResultSize { get; set; }

        public double p, q, s;
        public int iterator;

        private int everyXMeasurement = 48;

        /// <summary>
        /// p, q, s
        /// </summary>
        public static new int AmountOfArguments => 3;

        public override double Solve(params double[] values)
        {
            this.p = values[0];
            this.q = values[1];
            this.s = values[2];

            double sum = 0;

            double[] tmpMeasurements = GetInverseProblemTemperatureMeasurements();
            for (int i = 0; i < Measurements.Length; i++)
            {
                sum += Math.Abs(Measurements[i] - tmpMeasurements[i]);
            }
            if (sum < 0.001)
            {
                ;
            }
            return sum;
        }


        /* public override double Solve(params double[] values)
        {
            this.p = values[0];
            this.q = values[1];
            this.s = values[2];
            
            double sum = 0;
            double[] measurements = GetDirectProblemTemperatureMeasurements(everyXMeasurement);
            InverseProblem.h = GetSecondThing2;
            double[] tmpMeasurements = GetProblemTemperatureMeasurements(this.InverseProblem, everyXMeasurement);
            for (int i = 0; i < measurements.Length; i++)
            {
                this.iterator = i;
                double firstPart = DirectProblem.T * measurements[i] * (i*DirectProblem.tau);
               
                //double secondPart = GetSecondThing(i, values) * measurements[i] * InverseProblem.tau;
                double secondPart = GetSecondThing(values[0], values[1], values[2], i) * measurements[i] * (i*DirectProblem.tau);
                double together = firstPart - secondPart;
                sum += Math.Pow(together, 2);
            }
            if(sum < 0.001)
            {
                ;
            }
            return sum;
        }*/

        private double GetSecondThing2(double t)
        {
            return (this.p * t * t) + (this.q * t) + this.s;
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
            double t = (everyXMeasurement * i) * DirectProblem.tau;

            this.p = p;
            this.q = q;
            this.s = s;
            return (p * Math.Pow(t, 2)) + (q * t) + s;
        }

        private double[] GetDirectProblemTemperatureMeasurements(int every)
        {
            int secondIndex = (int)(Temperature[0].Length * 0.8);
            SecondIndex = secondIndex;
            int resultSize = Temperature.Length / every;
            ResultSize = resultSize;
            double[] result = new double[resultSize];
            for (int i = 0; i < resultSize; i++)
            {
                result[i] = Temperature[i * every][secondIndex];
            }
            return result;
        }

        private double[] GetInverseProblemTemperatureMeasurements()
        {
            var temp = InverseProblem.Solve();
            double[] result = new double[ResultSize];
            for (int i = 0; i < ResultSize; i++)
            {
                result[i] = temp[i * everyXMeasurement][SecondIndex];
            }
            return result;
        }
    }
}
