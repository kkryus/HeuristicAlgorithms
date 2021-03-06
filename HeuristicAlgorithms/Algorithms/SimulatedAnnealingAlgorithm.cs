﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeuristicAlgorithms.Functions;
using HeuristicAlgorithms.Utilities;
using System.IO;
using HeuristicAlgorithms.Models;
using HeuristicAlgorithms.Models.CustomControlUtilitiesClasses;

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

        public SimulatedAnnealingAlgorithm(TestingFunction function, int amountOfArguments, SASolverParametersModel parameters)
        {
            Function = function;
            AmountOfArguments = amountOfArguments;
            Arguments = new double[amountOfArguments];
            Arguments2 = new double[amountOfArguments];
            BeginingTemperature = parameters.BeginingTemperature;
            EndingTemperature = parameters.EndingTemperature;
            Iterations = parameters.Iterations;
            Cooling = parameters.Cooling;
            SatisfactionSolutionValue = parameters.SatisfactionSolution;
        }
        #endregion


        #region Fields
        private int maxCounter = 0;

        private int amountOfArguments;
        #endregion

        #region Properties
        #region Parameters
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
                            return bestSolution;
                        }
                    }
                }
                temperature *= Cooling;
                counter++;
            }
            return bestSolution;
        }

        public string GetCurrentProblemGUISolution()
        {
            string result = "";
            for(int i = 0; i < AmountOfArguments; i++)
            {
                result += "x" + i + "= " + Arguments[i] + Environment.NewLine;
            }
            return result;
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

        #endregion

        #region Utilities Methods

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

        public int[] GetIterationsArray()
        {
            int arraySize = 10;
            int beginingValue = 10000;
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
