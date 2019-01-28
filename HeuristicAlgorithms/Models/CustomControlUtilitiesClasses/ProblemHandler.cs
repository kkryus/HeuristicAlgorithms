using System.Collections.Generic;

namespace HeuristicAlgorithms.Models.CustomControlUtilitiesClasses
{
    public class ProblemHandler
    {
        #region SingletonImplementation
            
        private ProblemHandler()
        {
            Prepare();          
        }

        private static ProblemHandler instance;
        public static ProblemHandler Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ProblemHandler();
                }
                return instance;
            }
        }
        #endregion

        private Dictionary<string, Dictionary<int, SASolverParametersModel>> ProblemParameters { get; set; }

        public List<Problem> Problems { get; private set; }

        public Problem GetSuggestedProblemWithParameters(string problemName, int dimensions)
        {
            var problem = ProblemParameters.TryGetValue(problemName, out Dictionary<int, SASolverParametersModel> firstLevelValue);
            if(firstLevelValue != null)
            {
                firstLevelValue.TryGetValue(dimensions, out SASolverParametersModel parameters);
                if (parameters != null)
                {
                    return new Problem(problemName, false, dimensions, parameters);
                }
                return null;
            }
            return null;
        }

        private void Prepare()
        {
            #region Parameters Values
            SASolverParametersModel quadratic = new SASolverParametersModel(0.5, 0.01, 1, 0.99);
            SASolverParametersModel rosenbrock = new SASolverParametersModel(20, 0.01, 500, 0.99);
            SASolverParametersModel rastrigin3 = new SASolverParametersModel(4, 0.01, 600, 0.99);
            SASolverParametersModel rastrigin5 = new SASolverParametersModel(10, 0.01, 90000, 0.99);
            SASolverParametersModel ihcp = new SASolverParametersModel(20, 0.01, 35000, 0.99);
            #endregion
            #region Dictionary
            
            ProblemParameters = new Dictionary<string, Dictionary<int, SASolverParametersModel>>();
            ProblemParameters.Add("Quadratic", new Dictionary<int, SASolverParametersModel>() { { 2, quadratic } });
            ProblemParameters.Add("Rastrigin", new Dictionary<int, SASolverParametersModel>() { { 3, rastrigin3 }, { 5, rastrigin5 } });
            ProblemParameters.Add("Rosenbrock", new Dictionary<int, SASolverParametersModel>() { { 3, rosenbrock } });         
            ProblemParameters.Add("IHCP", new Dictionary<int, SASolverParametersModel>() { { 3, ihcp } });
            #endregion
            #region GUI Problems Representation
            Problems = new List<Problem>
            {
                new Problem("Quadratic", false, 2, quadratic),
                new Problem("Rastrigin", true, 3, rastrigin3),
                new Problem("Rosenbrock", true, 3, rosenbrock),               
                new Problem("IHCP", false, 3, ihcp)
            };
            #endregion
        }

    }
}
