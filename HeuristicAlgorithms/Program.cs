using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeuristicAlgorithms.Functions;
using HeuristicAlgorithms.Models;
using System.IO;
using HeuristicAlgorithms.Utilities;

namespace HeuristicAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 1%
            String line = "";
            try
            {   // Open the text file using a stream reader.
                using (StreamReader sr = new StreamReader(@"D:\ihcp\temperatures\temperaturesPercent1.txt"))
                {
                    // Read the stream to a string, and write the string to the console.
                    line = sr.ReadToEnd();
                    Console.WriteLine(line);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            string[] lines = line.Split(
                new[] { "\r\n", "\r", "\n" },
                StringSplitOptions.None
            );
            var temps = Array.ConvertAll(lines, Double.Parse);
            #endregion
            #region 2%
            line = "";
            try
            {   // Open the text file using a stream reader.
                using (StreamReader sr = new StreamReader(@"D:\ihcp\temperatures\temperaturesPercent2.txt"))
                {
                    // Read the stream to a string, and write the string to the console.
                    line = sr.ReadToEnd();
                    Console.WriteLine(line);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            lines = line.Split(
                new[] { "\r\n", "\r", "\n" },
                StringSplitOptions.None
            );
            var temps2 = Array.ConvertAll(lines, Double.Parse);
            #endregion
            #region 5%
            line = "";
            try
            {   // Open the text file using a stream reader.
                using (StreamReader sr = new StreamReader(@"D:\ihcp\temperatures\temperaturesPercent5.txt"))
                {
                    // Read the stream to a string, and write the string to the console.
                    line = sr.ReadToEnd();
                    Console.WriteLine(line);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            lines = line.Split(
                new[] { "\r\n", "\r", "\n" },
                StringSplitOptions.None
            );
            var temps5 = Array.ConvertAll(lines, Double.Parse);
            #endregion
            ;
            UtilitiesMethods tmp = new UtilitiesMethods();
            DirectProblem faisnd = new DirectProblem(tmp.f, tmp.g, tmp.h, 1, 1, 15, 480, 1, 1, 1);
            InverseHeatConductionProblemFunction inverseHeatConductionProblemFunction0 = new InverseHeatConductionProblemFunction(faisnd, 0);
            InverseHeatConductionProblemFunction inverseHeatConductionProblemFunction1 = new InverseHeatConductionProblemFunction(faisnd, 1, temps);
            InverseHeatConductionProblemFunction inverseHeatConductionProblemFunction2 = new InverseHeatConductionProblemFunction(faisnd, 2, temps2);
            InverseHeatConductionProblemFunction inverseHeatConductionProblemFunction5 = new InverseHeatConductionProblemFunction(faisnd, 5, temps5);
            SimulatedAnnealingAlgorithm simulatedAnnealinga0 = new SimulatedAnnealingAlgorithm(inverseHeatConductionProblemFunction0, 3, 20, 0.001, 35000, 0.99, 0.001);
            SimulatedAnnealingAlgorithm simulatedAnnealinga1 = new SimulatedAnnealingAlgorithm(inverseHeatConductionProblemFunction1, 3, 20, 0.001, 35000, 0.99, 0.001);
            SimulatedAnnealingAlgorithm simulatedAnnealinga2 = new SimulatedAnnealingAlgorithm(inverseHeatConductionProblemFunction2, 3, 20, 0.001, 35000, 0.99, 0.001);
            SimulatedAnnealingAlgorithm simulatedAnnealinga5 = new SimulatedAnnealingAlgorithm(inverseHeatConductionProblemFunction5, 3, 20, 0.001, 35000, 0.99, 0.001);
            simulatedAnnealinga0.Solve();
            simulatedAnnealinga1.Solve();
            simulatedAnnealinga2.Solve();
            simulatedAnnealinga5.Solve();
            /* Parallel.Invoke(
                 () => simulatedAnnealinga0.Solve(),
                 () => simulatedAnnealinga1.Solve()
                 //() => simulatedAnnealinga2.Solve(),
                 //() => simulatedAnnealinga5.Solve()
                 );*/
            ;


            //var oko = simulatedAnnealinga.Solve();//*/
            //inverseHeatConductionProblemFunction.Solve(1, 2, 3);
            //faisnd.Solve();

            // bool algorithm = true;
            //bool circle = !true;
            /*if (algorithm)
            {
                //IAlgorithm<double[]> simulatedAnnealing;
                SimulatedAnnealingAlgorithm simulatedAnnealing;
                if (circle)
                {
                    simulatedAnnealing = new SimulatedAnnealingAlgorithm(new CircleFunction(), CircleFunction.AmountOfArguments);
                    //simulatedAnnealing = new SimulatedAnnealingAlgorithm(new EasomFunction(), EasomFunction.AmountOfArguments);
                }
                else
                {
                    simulatedAnnealing = new SimulatedAnnealingAlgorithm(new RastriginFunction(), RastriginFunction.AmountOfArguments, 1000, 0.001, 50000, 0.99, 0.001);
                    // simulatedAnnealing = new SimulatedAnnealingAlgorithm(new RosenbrockFunction(), RosenbrockFunction.AmountOfArguments, 4000, 0.001, 5000, 0.99);
                }
                //var sol = simulatedAnnealing.Solve();
               // ;
                //var cooling = simulatedAnnealing.GetCoolingArray();
                // var temp = simulatedAnnealing.GetBeginingTemperatureArray();
                //var ending = simulatedAnnealing.GetEndingTemperatureArray();
                //var iterations = simulatedAnnealing.GetIterationsArray();
                List<AnnealingTestingModel> lista = new List<AnnealingTestingModel>();
                List<double> lists = new List<double>();

                for (int i = 0; i < 50; i++)
                {
                    lists.Add(simulatedAnnealing.Solve());
                   // lista.Add(simulatedAnnealing.Solve2(500, 0.001, 100000, 0.99));
                }

                lista = lista.OrderBy(x => x.bestSolution).ToList();
                ;/**/
            //for(int i = 0; i < temp.Length; i++)
            //for (int i = 0; i < 2; i++)
            // {
            /*for(int j = 0; j < iterations.Length; j++)
            //for (int j = 0; j < 2; j++)
            {
                lista.Add(simulatedAnnealing.Solve2(5000, 0.001, iterations[j], 0.99));
            }*/
            //  }
            /* lista = lista.OrderBy(x => x.bestSolution).ToList();//*/

            /*File.AppendAllText(@"d:\secondTable.txt", @"\begin{tabularx}{\textwidth}{ | >{\rownum}c|X|X|X|} 
             \hline
             & \textbf{ T0}
             & \textbf{ Iteracje}
             &\textbf{ Rozwiązanie}\\ \hline");
            for (int i = 0; i < lista.Count; i++)
            {
                File.AppendAllText(@"d:\thirdTable.txt",
                    String.Format("& {0} & {1} & {2} \\\\ \\hline ", lista[i].beginingTemperature, lista[i].iterations, lista[i].bestSolution) + Environment.NewLine);
            }

            File.AppendAllText(@"d:\firstTable.txt", @"\end{tabularx}");//*/

            //RosenbrockFunction oko = new RosenbrockFunction();
            //var foo = oko.Solve(100, 55);
            // double elapsedMs = 0;
            //for (int h = 0; h < 10; h++)
            //{
            //var watch = System.Diagnostics.Stopwatch.StartNew();
            #region Wyniki
            //40k = 80%
            //50k = 86%
            //86%                    
            //60k = 78%
            //-------
            //dla temperatury = 100 i iteracji 50k
            //9/30
            //dla temperatury = 1000 i iteracji 50k
            //10/50 = 80%
            //dla 3k temperatury, 50k iteracji, 0.9 cooling
            //wyniki zle
            //dla 4k temp, 50k iteracji, 0.01 i 0.99
            //80%
            // dla 3k temp, 50k iteracji, 0.001, 0.99
            //wyniki zle
            #endregion
            //simulatedAnnealing.Solve3(4000, 0.001, 1650, 0.99);
            //var okooo = simulatedAnnealing.Solve2();
            //lista.Add(simulatedAnnealing.Solve3(4000, 0.001, 1650, 0.99));
            //watch.Stop();
            //elapsedMs += watch.ElapsedMilliseconds;
            //}
            //tutaj stawiajac breakpoint's mozna przy debugowaniu zobaczyc wynik
            // lista = lista.OrderBy(x => x.bestSolution).ToList();
            #region Zapisywanie do pliku testow, zakomentowane
            /*for(int i = 0; i < lista.Count; i++)
            {
                File.AppendAllText(@"d:\bestSolution3.txt", 
                    "best solution: " + lista[i].bestSolution +
                    "|tmpbestsolution: " + lista[i].tmpBestSolution +
                    "|beginingTemperature: " + lista[i].beginingTemperature +
                    "|endingTemperature: " + lista[i].endingTemperature +
                    "|cooling: " + lista[i].cooling +
                    "|iterations: " + lista[i].iterations +
                    Environment.NewLine);
            }

            lista = lista.OrderBy(x => x.tmpBestSolution).ToList();
            for (int i = 0; i < lista.Count; i++)
            {
                File.AppendAllText(@"d:\tmpBestSolution3.txt",
                    "best solution: " + lista[i].bestSolution +
                    "|tmpbestsolution: " + lista[i].tmpBestSolution +
                    "|beginingTemperature: " + lista[i].beginingTemperature +
                    "|endingTemperature: " + lista[i].endingTemperature +
                    "|cooling: " + lista[i].cooling +
                    "|iterations: " + lista[i].iterations +
                    Environment.NewLine);
            }
            ;
            /**/
            #endregion

            //double elapsedMs = 0;
            /*for (var i = 0; i < 100; i++)
            {
                var watch = System.Diagnostics.Stopwatch.StartNew();					
                //Console.WriteLine();
                simulatedAnnealing.Solve();
                watch.Stop();
                elapsedMs += watch.ElapsedMilliseconds;
            }*/
            //elapsedMs /= 100;
            //string oko = "";
            /* }
             else
             {
                 IAlgorithm<FireflyModel[]> firefly = new FireflyAlgorithm();
                 if (circle)
                 {
                     firefly.AmountOfArguments = 2;
                     firefly.Function = new CircleFunction();
                     firefly.Solve();
                 }
                 else
                 {

                 }

             }

             Console.ReadKey();
         }*/


        }
    }
}
