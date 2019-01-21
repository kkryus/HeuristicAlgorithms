using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeuristicAlgorithms.Models.CustomControlUtilitiesClasses
{
    public class RegularProblemHandler
    {
        #region SingletonImplementation
            
        private RegularProblemHandler()
        {
            RegularProblems = new List<RegularProblem>();
            RegularProblems.Add(new RegularProblem("Rastrigin", true, 3));
            RegularProblems.Add(new RegularProblem("Rosenbrock", true, 3));
            RegularProblems.Add(new RegularProblem("Quadratic", false, 2));
        }

        private static RegularProblemHandler instance;
        public static RegularProblemHandler Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RegularProblemHandler();
                }
                return instance;
            }
        }
        #endregion

        public List<RegularProblem> RegularProblems { get; private set; }

    }
}
