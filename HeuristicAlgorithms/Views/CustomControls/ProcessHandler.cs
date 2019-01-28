using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using HeuristicAlgorithms.Functions;
using System.Threading;
using HeuristicAlgorithms.Models.CustomControlUtilitiesClasses;
using HeuristicAlgorithms.Utilities;

namespace HeuristicAlgorithms.Views.CustomControls
{
    public partial class ProcessHandler : UserControl
    {
        public event Func<Problem> TaskGetter;
        public event Action<bool> FireToggleButtons;
        public event Action<string> tmpEvent;
        private CancellationTokenSource cts;
        public ProcessHandler()
        {
            InitializeComponent();
            tmpEvent += SetResultText;
            FireToggleButtons += ToggleButtons;
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            this.Invoke(FireToggleButtons, false);
            try
            {
                var problemToSolve = TaskGetter.Invoke();
                SimulatedAnnealingAlgorithm simulatedAnnealing;
                switch (problemToSolve.ProblemName)
                {
                    case "Quadratic":
                        simulatedAnnealing = new SimulatedAnnealingAlgorithm(new QuadraticFunction(), 2, 10, 0.01, 1000, 0.99);
                        break;
                    case "Rastrigin":
                        simulatedAnnealing = new SimulatedAnnealingAlgorithm(new RastriginFunction(), problemToSolve.DefaultDimensions, problemToSolve.Parameters);
                        break;
                    case "Rosenbrock":
                        simulatedAnnealing = new SimulatedAnnealingAlgorithm(new RosenbrockFunction(), problemToSolve.DefaultDimensions, problemToSolve.Parameters);
                        break;
                    case "IHCP":
                        UtilitiesMethods utilitiesMethods = new UtilitiesMethods();
                        DirectProblem directProblem = new DirectProblem(utilitiesMethods.f, utilitiesMethods.g, utilitiesMethods.h, 1, 1, 15, 480, 1, 1, 1);
                        InverseHeatConductionProblemFunction inverseHeatConductionProblemFunction = new InverseHeatConductionProblemFunction(directProblem, 0);
                        simulatedAnnealing = new SimulatedAnnealingAlgorithm(inverseHeatConductionProblemFunction, 3, problemToSolve.Parameters);
                        break;
                    default:
                        throw new Exception("Problem not implemented.");
                }
                Task<double> task = null;
                var parent = this;
                SetResultText("Calculating...");
                task = Task.Run(() =>
               {
                   cts = new CancellationTokenSource();
                   CancellationToken token = cts.Token;
                   try
                   {
                       Task.Run(() =>
                      {
                          try
                          {
                              while (true)
                              {
                                  Thread.Sleep(100);
                                  token.ThrowIfCancellationRequested();
                              }
                          }
                          catch (Exception ep)
                          {
                              parent.Invoke(tmpEvent, "Process stoped.");
                              parent.Invoke(FireToggleButtons, true);
                          }
                      }, token);
                   }
                   catch (Exception exc)
                   {
                       MessageBox.Show(exc.Message, "Information");
                   }
                   double solutionValue = 0;
                   if (simulatedAnnealing != null)
                   {
                       solutionValue = simulatedAnnealing.Solve();
                       parent.Invoke(tmpEvent, "Problem name: " + problemToSolve.ProblemName + ", Dimensions: " + problemToSolve.DefaultDimensions + Environment.NewLine +
                           "Real solution: " + simulatedAnnealing.Function.Solution + Environment.NewLine +
                           "Founded solution: " + solutionValue + Environment.NewLine + simulatedAnnealing.GetCurrentProblemGUISolution());
                       parent.Invoke(FireToggleButtons, true);
                   }
                   return solutionValue;


               });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Information");
            }
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            cts.Cancel();
            StartButton.Enabled = true;
            StopButton.Enabled = false;
        }
        public void SetResultText(string text)
        {
            this.ResultTextBox.Text = text;
        }

        public void ToggleButtons(bool startOn)
        {
            StartButton.Enabled = startOn;
            StopButton.Enabled = !startOn;
        }
    }
}
