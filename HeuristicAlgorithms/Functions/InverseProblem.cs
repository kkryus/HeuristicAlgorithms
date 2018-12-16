using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeuristicAlgorithms.Functions
{
    class InverseProblem
    {

        public double[][] Solve(Func<double, double> f, Func<double, double> g, Func<double, double> h, double a, double T, int nx, int nt, double c, double rho, double lambda)
        {
            double[][] temp = new double[nt + 1][];
            for (int i = 0; i < nt + 1; i++)
            {
                temp[i] = new double[nx + 1];
                for (int j = 0; j < nx + 1; j++)
                {
                    temp[i][j] = 0;
                }
            }
            double hx = a / nx;
            double tau = T / nt;
            if (tau / (hx * hx) >= 0.5)
            {
                Console.WriteLine("Niestabline");
            }
            var x = new double[nx + 1];
            for (int i = 0; i < nx + 1; i++)
            {
                x[i] = i * hx;
            }
            for (int i = 0; i < nx + 1; i++)
            {
                temp[0][i] = f(x[i]);
            }
            for (int i = 0; i < nt + 1; i++)
            {
                temp[i][0] = g((i) * tau);
                temp[i][nx] = h((i) * tau);
            }
            var wsp = lambda * tau / (hx * hx * c * rho);
            for (int j = 1; j < nt + 1; j++)
            {
                for (int i = 1; i < nx; i++)
                {
                    temp[j][i] = wsp * (temp[j - 1][i - 1] - 2.0 * temp[j - 1][i] + temp[j - 1][i + 1]) + temp[j - 1][i];
                }
            }
            return temp;
        }
    }
}
