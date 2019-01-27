using System;
using System.Windows.Forms;
using HeuristicAlgorithms.Models.CustomControlUtilitiesClasses;

namespace HeuristicAlgorithms
{
    public partial class MainView : Form
    {
        public MainView()
        {
            InitializeComponent();
            this.ProblemControl.ProblemChanged += this.ProblemReceiver;
            this.ProcessHandler.TaskGetter += GetProblemToSolve;
        }
   
        private void MainView_Resize(object sender, EventArgs e)
        {
            //this.tabsControl.ItemSize = new Size(this.tabsControl.Width / 2 - 2, this.tabsControl.ItemSize.Height);
        }

        /// <summary>
        /// Gets info from all controls and returns in one object
        /// </summary>
        /// <returns>Problem to solve</returns>
        private Problem GetProblemToSolve()
        {
            try
            {
                Problem problem = this.ProblemControl.GetProblem();
                problem.Parameters = this.SaAlgorithmParameters.GetParameters();
                return problem;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Information");
                return null;
            }
        }

        /// <summary>
        /// This method receives problem and sets parameters in GUI
        /// </summary>
        /// <param name="problem">Problem model</param>
        private void ProblemReceiver(Problem problem)
        {
            if(problem?.Parameters != null)
            {
                SaAlgorithmParameters.SetParameters(problem.Parameters);
            }           
        }
    }
}
