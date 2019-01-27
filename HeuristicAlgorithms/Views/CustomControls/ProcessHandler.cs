using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using HeuristicAlgorithms.Functions;
using System.Threading;
using HeuristicAlgorithms.Models.CustomControlUtilitiesClasses;

namespace HeuristicAlgorithms.Views.CustomControls
{
    public partial class ProcessHandler : UserControl
    {
        public event Func<Problem> TaskGetter;
        public event Action tmpEvent;
        private CancellationTokenSource cts;
        public bool a = false;
        public ProcessHandler()
        {
            InitializeComponent();
            tmpEvent += Oczko;
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            try
            {
                var problemToSolve = TaskGetter.Invoke();
                SimulatedAnnealingAlgorithm simulatedAnnealing;
                switch (problemToSolve.ProblemName)
                {
                    case "Quadratic":
                        simulatedAnnealing = new SimulatedAnnealingAlgorithm(new CircleFunction(), 5, 10, 0.01, 1000, 0.99);
                        break;
                    case "Rastrigin":
                        simulatedAnnealing = new SimulatedAnnealingAlgorithm(new CircleFunction(), 5, 10, 0.01, 1000, 0.99);
                        break;
                    case "Rosenbrock":
                        simulatedAnnealing = new SimulatedAnnealingAlgorithm(new CircleFunction(), 5, 10, 0.01, 1000, 0.99);
                        break;
                    case "IHCP":
                        simulatedAnnealing = new SimulatedAnnealingAlgorithm(new CircleFunction(), 5, 10, 0.01, 1000, 0.99);
                        break;
                    default:
                        return;
                        break;
                }
                //SimulatedAnnealingAlgorithm simulatedAnnealing = new SimulatedAnnealingAlgorithm(new RastriginFunction(), 5, 10, 0.01, 1000, 0.99);
                Task<double> task = null;
                var parent = this;
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
                          catch(Exception ep)
                          {
                              parent.Invoke(tmpEvent);
                          }
                      }, token);
                   }
                   catch (Exception exc)
                   {
                       //this.ResultTextBox.Text = "kuniec";
                   }
                   var oko = simulatedAnnealing.Solve();
                   parent.Invoke(tmpEvent);
                   return oko;
               });
            }
            catch (Exception ex)
            {
                //this.ResultTextBox.Text = "kuniec";
            }
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            cts.Cancel();
        }
        public void Oczko()
        {
            this.ResultTextBox.Text = "kuniec";
        }
    }
}
