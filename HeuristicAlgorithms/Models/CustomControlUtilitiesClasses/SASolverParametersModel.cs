using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeuristicAlgorithms.Models.CustomControlUtilitiesClasses
{
    public class SASolverParametersModel
    {
        public SASolverParametersModel(double beginingTemperature, double endingTemperature, int iterations, double cooling, double? satisfactionSolution = null)
        {
            BeginingTemperature = beginingTemperature;
            EndingTemperature = endingTemperature;
            Iterations = iterations;
            Cooling = cooling;
            SatisfactionSolution = satisfactionSolution;
        }
        /// <summary>
        /// Iterations process will start on that level
        /// </summary>
        public double BeginingTemperature { get; set; }

        /// <summary>
        /// Iterations process will end on that level
        /// </summary>
        public double EndingTemperature { get; set; }

        /// <summary>
        /// Amount of inner iterations
        /// </summary>
        public int Iterations { get; set; }

        /// <summary>
        /// How much times temperature will drop after every Iterations
        /// </summary>
        public double Cooling { get; set; }

        /// <summary>
        /// Optional. Value, that would be satisfactory.
        /// </summary>
        public double? SatisfactionSolution { get; set; }     
    }
}
