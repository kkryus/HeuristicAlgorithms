
namespace HeuristicAlgorithms.Models.CustomControlUtilitiesClasses
{
    public class Problem
    {
        public Problem(string problem, bool hasDimensions, int defaultDimensions, SASolverParametersModel parameters)
        {
            ProblemName = problem;
            HasDimensions = hasDimensions;
            DefaultDimensions = defaultDimensions;
            Parameters = parameters;
        }

        /// <summary>
        /// GUI's problem's name
        /// </summary>
        public string ProblemName { get; set; }

        /// <summary>
        /// Are dimensions changeable
        /// </summary>
        public bool HasDimensions { get; set; }

        /// <summary>
        /// Default amount of dimensions
        /// </summary>
        public int DefaultDimensions { get; set; }

        /// <summary>
        /// Suggested parameters for simulated annealing algorithm for this problem
        /// </summary>
        public SASolverParametersModel Parameters { get; set; }
    }
}
