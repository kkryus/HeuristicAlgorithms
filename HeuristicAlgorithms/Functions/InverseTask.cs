using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeuristicAlgorithms.Functions
{
    class InverseTask
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
            if(tau/(hx*hx) >= 0.5)
            {
                Console.WriteLine("Niestabline");
            }
            //+1, bo w mathematice jest 16 łącznie, brakuje ostatniego
            var x = new double[nx +1];
            //+1, bo w mathematice jest 16 łącznie, brakuje ostatniego
            for (int i = 0; i < nx +1; i++)
            {
                x[i] = i * hx;
            }
            for(int i = 0; i < nx + 1; i++)
            {
                temp[1][i] = f(x[i]);
            }
            for(int i = 0; i < nt + 1; i++)
            {
                temp[i][1] = g((i - 1) * tau);
                temp[i][nx + 1] = h((i - 1) * tau);//<--------
                //Do[temp[[i, 1]] = g[(i - 1)*tau]; 
               // temp[[i, nx + 1]] = h[(i - 1) * tau], { i, 2, nt + 1}];
            }
            var wsp = lambda * tau / (hx * hx * c * rho);
            for(int i = 2; i < nx; i++)
            {
                for(int j = 2; j < nt + 1; j++)
                {
                    temp[j][i] = wsp * temp[j - 1][i - 1] - 2.0 * temp[j - 1][i] + temp[j - 1][i + 1] + temp[j - 1][i];
                }
            }
            return temp;
        }
    }
}
