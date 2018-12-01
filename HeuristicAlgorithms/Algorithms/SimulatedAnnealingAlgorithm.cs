﻿using System;
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

        public SimulatedAnnealingAlgorithm(TestingFunction function, int amountOfArguments, double beginingTemperature, double endingTemperature, double iterations, double cooling)
        {
            Function = function;
            AmountOfArguments = amountOfArguments;
            Arguments = new double[amountOfArguments];
            Arguments2 = new double[amountOfArguments];
            BeginingTemperature = beginingTemperature;
            EndingTemperature = endingTemperature;
            Iterations = iterations;
            Cooling = cooling;
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
            while (temperature > EndingTemperature || bestSolution > 0.01)
            {
                for (int i = 0; i < Iterations; i++)
                {
                    Move(counter);
                    double tmpSolution = Function.Solve(Arguments2);

                    if (tmpSolution < bestSolution || ShouldChangeAnyway(bestSolution - tmpSolution, temperature))
                    {
                        bestSolution = tmpSolution;
                        CopyValues();
                    }
                }
                temperature *= Cooling;
                counter++;
            }

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
            //Obliczanie maxCountera
            {
                maxCounter = 0;
                double tmpTemperature = beginingTemperature;
                while (tmpTemperature > endingTemperature)
                {
                    tmpTemperature *= cooling;
                    maxCounter++;
                }
            }

            #region Sumaryczne wartosci wynikowe
            //double best = 0;
            //double temp = 0;
            //double tempbest = 0;
            #endregion
            #region Poczatkowe wartosci musze zainicjowac, aby na samym dole ich uzywac, a wysoka liczba i tak bedzie zmniejszona poprzez wywolanie funkcji
            //double bestSolution = 10000000000;
            double tmpBestSolution = 1000000000000;
            double tmpSolution = 100000;
            #endregion
            //int repetitions = 1;
            //Licznik ile razy dana temperatura sie zmniejszy az osiagnie wartosc minimalna
            int counter = 0;
            //zeby wynik byl w miare pewny, powtarzam dzialanie pewna ilosc razy sumujac wyniki, a nastepnie dzielac przez ilosc powtorzen
            //for (int k = 0; k < repetitions; k++)
            //{
            //Losuje poczatkowe argumenty dla tablicy Arguments				
            DrawArguments();
            //bestSolution = Function.Solve(Arguments);
            tmpBestSolution = Function.Solve(Arguments);
            tmpSolution = Function.Solve(Arguments);

            //Dla kazdego nowego powtorzenia zaczynam od poczatkowej, wysokiej temperatury
            double temperature = beginingTemperature;
            while (temperature > endingTemperature)
            {
                for (int i = 0; i < iterations; i++)
                {
                    //Wykonuje pewien losowy ruch argumentow
                    //Wybiera sasiadow z tablicy Arguments do tablicy Arguments2
                    Move(counter);
                    tmpSolution = Function.Solve(Arguments2);
                    //if (tmpSolution < bestSolution)
                    //{
                    //	bestSolution = tmpSolution;
                    //}
                    if (tmpSolution < tmpBestSolution)
                    {
                        tmpBestSolution = tmpSolution;
                        CopyValues();
                    }
                    //Funkcja prawdopodobienstwa, nawet jezeli wynik jest gorszy, to z pewnym prawdopodobienstwem je zamieni
                    else if (ShouldChangeAnyway(tmpBestSolution - tmpSolution, temperature))
                    {
                        tmpBestSolution = tmpSolution;
                        CopyValues();
                    }
                }
                temperature *= cooling;
                counter++;
                //}
                //best += bestSolution;
                //temp += tmpSolution;
                //tempbest += tmpBestSolution;
                //counter = 0;
            }
            return new AnnealingTestingModel()
            {
                beginingTemperature = beginingTemperature,
                endingTemperature = endingTemperature,
                iterations = iterations,
                cooling = cooling,
                //bestSolution = bestSolution,// / repetitions,
                tmpBestSolution = tmpBestSolution,// / repetitions,
                tmpSolution = tmpSolution,// / repetitions
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
            double value = (0.8 * domainValue) * (leftPercent);
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

        #endregion

        #region Utilities Methods
        //500-5000?
        //drop = 500?
        // ->20?
        public double[] GetBeginingTemperatureArray()
        {
            int arraySize = 8;
            double beginingValue = 4001;
            double dropValue = 500;
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
        //100 - 3000
        //every 250?
        // -> 15?
        public int[] GetIterationsArray()
        {
            int arraySize = 13;
            int beginingValue = 100;
            int riseValue = 250;
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
