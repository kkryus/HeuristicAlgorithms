using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HeuristicAlgorithms.Functions
{
    class InverseHeatConductionProblemFunction : TestingFunction
    {
        public InverseHeatConductionProblemFunction(DirectProblem directProblem, int percent)
        {
            DirectProblem = directProblem;
            Temperature = DirectProblem.Solve();
            Measurements = GetDirectProblemTemperatureMeasurements(everyXMeasurement);
            var tmp = Measurements;
            Percent = percent;
            if(percent > 0)
            {
                Utilities.UtilitiesMethods.WorsenTemperature(percent, ref tmp);
            }
           // File.AppendAllText(@"d:\temperaturesPercent" + percent + ".txt", 

            for (int i = 0; i < Measurements.Length; i++)
            {
                File.AppendAllText(@"d:\temperaturesPercent" + percent + ".txt",
                    String.Format("{0}", Measurements[i] + Environment.NewLine));
            }

            //File.AppendAllText(@"d:\firstTable.txt", @"\end{tabularx}");

            InverseProblem = new DirectProblem(directProblem.f, directProblem.g, GetSecondThing2, directProblem.a, directProblem.T, directProblem.nx, directProblem.nt, directProblem.c, directProblem.rho, directProblem.lambda);
        }

        public InverseHeatConductionProblemFunction(DirectProblem directProblem, int percent, double[] temperatures)
        {
            DirectProblem = directProblem;
            Temperature = DirectProblem.Solve();
            Measurements = temperatures;
            Percent = percent;
            GetDirectProblemTemperatureMeasurements(everyXMeasurement);
            // File.AppendAllText(@"d:\temperaturesPercent" + percent + ".txt", 

            /*for (int i = 0; i < Measurements.Length; i++)
            {
                File.AppendAllText(@"d:\temperaturesPercent" + percent + ".txt",
                    String.Format("{0}", Measurements[i] + Environment.NewLine));
            }*/

            //File.AppendAllText(@"d:\firstTable.txt", @"\end{tabularx}");

            InverseProblem = new DirectProblem(directProblem.f, directProblem.g, GetSecondThing2, directProblem.a, directProblem.T, directProblem.nx, directProblem.nt, directProblem.c, directProblem.rho, directProblem.lambda);
        }

        public DirectProblem DirectProblem { get; set; }
        public DirectProblem InverseProblem { get; private set; }

        public override double LeftBound => -10;

        public override double RightBound => 10;

        public double Percent { get; set; }

        public double[][] Temperature { get; set; }

        public double[] Measurements { get; set; }

        public int SecondIndex { get; set; }
        public int ResultSize { get; set; }

        public double p, q, s;

        private readonly int everyXMeasurement = 48;

        public static new int AmountOfArguments => 3;

        public override double Solution => 0;

        public override double Solve(params double[] values)
        {
            this.p = values[0];
            this.q = values[1];
            this.s = values[2];

            double sum = 0;

            double[] tmpMeasurements = GetTemperatureMeasurements();
            for (int i = 0; i < Measurements.Length; i++)
            {
                sum += Math.Pow(Measurements[i] - tmpMeasurements[i], 2);
            }
            return sum;
        }

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

        private double[] GetTemperatureMeasurements()
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
