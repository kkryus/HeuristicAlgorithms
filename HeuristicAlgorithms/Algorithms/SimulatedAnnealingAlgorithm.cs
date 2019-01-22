using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeuristicAlgorithms.Functions;
using HeuristicAlgorithms.Utilities;
using System.IO;
using HeuristicAlgorithms.Models;

namespace HeuristicAlgorithms
{
    public class SimulatedAnnealingAlgorithm : IAlgorithm<double[]>
    {
        #region Constructors
        public SimulatedAnnealingAlgorithm(TestingFunction function, int amountOfArguments)
        {
            Function = function;
            AmountOfArguments = amountOfArguments;
            Arguments = new double[amountOfArguments];
            Arguments2 = new double[amountOfArguments];
        }

        public SimulatedAnnealingAlgorithm(TestingFunction function, int amountOfArguments, double beginingTemperature, double endingTemperature, double iterations, double cooling, double? satisfactionSolutionValue = null)
        {
            Function = function;
            AmountOfArguments = amountOfArguments;
            Arguments = new double[amountOfArguments];
            Arguments2 = new double[amountOfArguments];
            BeginingTemperature = beginingTemperature;
            EndingTemperature = endingTemperature;
            Iterations = iterations;
            Cooling = cooling;
            SatisfactionSolutionValue = satisfactionSolutionValue;
        }
        #endregion


        #region Fields
        private int maxCounter = 0;

        private int amountOfArguments;
        #endregion

        #region Properties
        #region Parameters
        //https://pdfs.semanticscholar.org/b145/faf936fbb2c1c6f8530a20dbe3c8538aedbf.pdf
        /// <summary>
        /// Algorithm will start with that degree of iterations
        /// </summary>
        public double BeginingTemperature { get; set; }
        /// <summary>
        /// Iterations ending condition
        /// </summary>
        public double EndingTemperature { get; set; }
        /// <summary>
        /// Every temperature algorithm will work this times
        /// </summary>
        public double Iterations { get; set; }
        /// <summary>
        /// Temperature will be multiplied by this factor, should be less than 1
        /// </summary>
        public double Cooling { get; set; }
        /// <summary>
        /// If solution will be lower than this, we can end process.
        /// </summary>
        public double? SatisfactionSolutionValue { get; set; }
        #endregion

        /// <summary>
        /// Amount of arguments.
        /// </summary>
        public int AmountOfArguments
        {
            get
            {
                return amountOfArguments;
            }
            set
            {
                amountOfArguments = value;
                Arguments = new double[value];
                Arguments2 = new double[value];
            }
        }

        /// <summary>
        /// Arguments for the Function.
        /// </summary>
        public double[] Arguments { get; private set; }

        /// <summary>
        /// Temporary arguments for the function
        /// </summary>
        public double[] Arguments2 { get; private set; }

        /// <summary>
        /// Function where global minimum will be searched.
        /// </summary>
        public TestingFunction Function { get; set; }

        #endregion

        #region Methods

        #region Public Methods
        /// <summary>
        /// Method searches global minimum using Simulated Annealing algorithm.
        /// </summary>
        /// <returns>Global minimum</returns>
        public double Solve()
        {
            SetMaxCounter();
            int counter = 0;

            DrawArguments();
            double bestSolution = Function.Solve(Arguments);

            double temperature = BeginingTemperature;
            while (temperature > EndingTemperature)
            {
                for (int i = 0; i < Iterations; i++)
                {
                    Move(counter);
                    double tmpSolution = Function.Solve(Arguments2);

                    if (tmpSolution < bestSolution || ShouldChangeAnyway(bestSolution - tmpSolution, temperature))
                    {
                        bestSolution = tmpSolution;
                        CopyValues();
                        if (SatisfactionSolutionValue != null && bestSolution < SatisfactionSolutionValue)
                        {
                           // File.AppendAllText(@"d:\resultPercent" + ((InverseHeatConductionProblemFunction)Function).Percent + ".txt",
                            //   String.Format("Error: {0} | P: {1} | Q: {2} | S: {3}", bestSolution, ((InverseHeatConductionProblemFunction)Function).p,
                           //     ((InverseHeatConductionProblemFunction)Function).q, ((InverseHeatConductionProblemFunction)Function).s + Environment.NewLine));
                            return bestSolution;
                        }
                    }
                }
                temperature *= Cooling;
                counter++;
            }
           // File.AppendAllText(@"d:\resultPercent" + ((InverseHeatConductionProblemFunction)Function).Percent + ".txt",
           //                     String.Format("Error: {0} | P: {1} | Q: {2} | S: {3}", bestSolution, ((InverseHeatConductionProblemFunction)Function).p,
            //                    ((InverseHeatConductionProblemFunction)Function).q, ((InverseHeatConductionProblemFunction)Function).s + Environment.NewLine));
            return bestSolution;
        }

        /// <summary>
        /// Method searches global minimum using Simulated Annealing algorithm, used for testing
        /// </summary>
        /// <param name="beginingTemperature">Algorithm will start with that degree of iterations</param>
        /// <param name="endingTemperature">Iterations ending condition</param>
        /// <param name="iterations">Every temperature algorithm will work this times</param>
        /// <param name="cooling">Temperature will be multiplied by this factor, should be less than 1</param>
        /// <returns></returns>
        public AnnealingTestingModel Solve2(double beginingTemperature, double endingTemperature, int iterations, double cooling)
        {
            double best2Solution = 0;
            int repetitions = 10;
            //double tmp2Solution = 0;
            for (int k = 0; k < repetitions; k++)
            {
                SetTmpMaxCounter(beginingTemperature, endingTemperature, cooling);
                int counter = 0;

                DrawArguments();
                double bestSolution = Function.Solve(Arguments);
                double tmpSolution = Function.Solve(Arguments);

                double temperature = beginingTemperature;
                while (temperature > endingTemperature)
                {
                    for (int i = 0; i < iterations; i++)
                    {
                        Move(counter);
                        tmpSolution = Function.Solve(Arguments2);

                        if (tmpSolution < bestSolution || ShouldChangeAnyway(bestSolution - tmpSolution, temperature))
                        {
                            bestSolution = tmpSolution;
                            CopyValues();
                        }
                    }
                    temperature *= cooling;
                    counter++;
                }
                best2Solution += bestSolution;
            }
            return new AnnealingTestingModel()
            {
                beginingTemperature = beginingTemperature,
                endingTemperature = endingTemperature,
                iterations = iterations,
                cooling = cooling,
                bestSolution = best2Solution / repetitions,// / repetitions,
                //tmpBestSolution = bestSolution,// / repetitions,
                //tmpSolution = tmpSolution,// / repetitions
            };
            //return bestSolution;
        }

        #endregion

        #region Private Methods
        /// <summary>
        /// Draws arguments.
        /// </summary>
        private void DrawArguments()
        {
            double leftBound = Function.LeftBound;
            double rightBound = Function.RightBound;
            for (int i = 0; i < AmountOfArguments; i++)
            {
                Arguments[i] = RandomGenerator.Instance.GetRandomDoubleInDomain(leftBound, rightBound);
            }
        }

        /// <summary>
        /// Moves arguments randomly a bit.
        /// </summary>
        /// <param name="counter">Which global iteration is now</param>
        private void Move(int counter)
        {
            double leftTemperatureCoolingTimes = maxCounter - counter;
            double leftPercent = leftTemperatureCoolingTimes / maxCounter;

            double domainValue = (Function.RightBound - Function.LeftBound);
            double partOfTheDomain = 0.8;
            double value = (partOfTheDomain * domainValue) * (leftPercent);
            for (int i = 0; i < AmountOfArguments; i++)
            {
                double newValue = Arguments[i] + RandomGenerator.Instance.GetRandomDoubleInDomain(-value, value);
                if (newValue < Function.LeftBound)
                {
                    newValue = Function.LeftBound;
                }
                if (newValue > Function.RightBound)
                {
                    newValue = Function.RightBound;
                }

                Arguments2[i] = newValue;
            }
        }

        /// <summary>
        /// Copy values from Arguments2 to Arguments
        /// </summary>
        private void CopyValues()
        {
            for (int i = 0; i < AmountOfArguments; i++)
            {
                Arguments[i] = Arguments2[i];
            }
        }

        /// <summary>
        /// Checks if solution should change altough it's not best.
        /// </summary>
        /// <param name="distance">Difference between better and worse values</param>
        /// <param name="temperature">Current temperature</param>
        /// <returns>If solution should change</returns>
        private bool ShouldChangeAnyway(double distance, double temperature)
        {
            return Math.Exp((distance / temperature)) >= RandomGenerator.Instance.NextDouble();
        }

        /// <summary>
        /// Counts and sets max amount of global iterations
        /// </summary>
        private void SetMaxCounter()
        {
            maxCounter = 0;
            double tmpTemperature = BeginingTemperature;
            while (tmpTemperature > EndingTemperature)
            {
                tmpTemperature *= Cooling;
                maxCounter++;
            }
        }
        private void SetTmpMaxCounter(double beginingTemperature, double endingTemperature, double cooling)
        {
            maxCounter = 0;
            double tmpTemperature = beginingTemperature;
            while (tmpTemperature > endingTemperature)
            {
                tmpTemperature *= cooling;
                maxCounter++;
            }
        }

        #endregion


        // 3 scenariusze:
        //1. niska temp(100-500, co 100 -> 5), niska ilosc iteracji(100-500, -> 5) -> slaby wynik -> 5*5 = 25
        //2. wieksza ilosc temp (1k-10k, co 2k -> 5), wieksza ilosc iteracji (1k-10k, co 2k) -> 5*5 = 25, wieksza temp nie daje az takich efektow, dlatego iteracje mocno zwiekszam
        //3. najlepsiejsza temp zostaje, iteracje 10k - 100k


        #region Utilities Methods
        //500-5000?
        //drop = 500?
        // ->20?
        //1k - 4k -> 4
        public double[] GetBeginingTemperatureArray()
        {
            int arraySize = 5;
            double beginingValue = 10;
            double dropValue = 2;
            double[] beginingTemperatureArray = new double[arraySize];
            for (int i = 0; i < arraySize; i++)
            {
                beginingTemperatureArray[i] = beginingValue;
                beginingValue -= dropValue;
            }
            return beginingTemperatureArray;
        }
        //0.1 - 0.001 min
        // 0.01?
        // - > 11x?
        public double[] GetEndingTemperatureArray()
        {
            int arraySize = 11;
            double beginingValue = 0.101;
            double dropValue = 0.01;
            double[] endingTemperatureArray = new double[arraySize];
            for (int i = 0; i < arraySize; i++)
            {
                endingTemperatureArray[i] = beginingValue;
                beginingValue -= dropValue;
            }
            return endingTemperatureArray;
        }
        //0.91 - 0.99
        //every 2nd
        // -> 10
        public double[] GetCoolingArray()
        {
            int arraySize = 5;
            double beginingValue = 0.91;
            double riseValue = 0.02;
            double[] coolingArray = new double[arraySize];
            for (int i = 0; i < arraySize; i++)
            {
                coolingArray[i] = beginingValue;
                beginingValue += riseValue;
            }
            return coolingArray;
        }
        //1000 - 10000
        //every 250?
        // -> 15?
        //1k - 60k
        //7
        public int[] GetIterationsArray()
        {
            int arraySize = 5;
            int beginingValue = 50000;
            int riseValue = 10000;
            int[] iterationsArray = new int[arraySize];
            for (int i = 0; i < arraySize; i++)
            {
                iterationsArray[i] = beginingValue;
                beginingValue += riseValue;
            }
            return iterationsArray;
        }
        #endregion

        #endregion
    }
}
