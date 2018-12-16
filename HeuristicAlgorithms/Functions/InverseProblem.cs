using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeuristicAlgorithms.Functions
{
    class InverseProblem
    {
        public InverseProblem(Func<double, double> f, Func<double, double> g, Func<double, double> h, double a, double T, int nx, int nt, double c, double rho, double lambda)
        {
            this.f = f;
            this.g = g;
            this.h = h;
            this.a = a;
            this.T = T;
            this.nx = nx;
            this.nt = nt;
            this.c = c;
            this.rho = rho;
            this.lambda = lambda;
            this.tau = T / nt;
        }

        public Func<double, double> f { get; set; }
        public Func<double, double> g { get; set; }
        public Func<double, double> h { get; set; }
        public double a { get; set; }
        public double T { get; set; }
        public int nx { get; set; }
        public int nt { get; set; }
        public double c { get; set; }
        public double rho { get; set; }
        public double lambda { get; set; }
        public double tau { get; private set; }
        

        public double[][] Solve()
        {
            double[][] temp = new double[this.nt + 1][];
            for (int i = 0; i < this.nt + 1; i++)
            {
                temp[i] = new double[this.nx + 1];
                for (int j = 0; j < this.nx + 1; j++)
                {
                    temp[i][j] = 0;
                }
            }
            double hx = a / nx;
            if (this.tau / (hx * hx) >= 0.5)
            {
                Console.WriteLine("Niestabline");
                return null;
            }
            var x = new double[this.nx + 1];
            for (int i = 0; i < this.nx + 1; i++)
            {
                x[i] = i * hx;
            }
            for (int i = 0; i < this.nx + 1; i++)
            {
                temp[0][i] = this.f(x[i]);
            }
            for (int i = 0; i < nt + 1; i++)
            {
                temp[i][0] = this.g((i) * this.tau);
                temp[i][this.nx] = this.h((i) * this.tau);
            }
            var wsp = this.lambda * this.tau / (hx * hx * this.c * this.rho);
            for (int j = 1; j < this.nt + 1; j++)
            {
                for (int i = 1; i < this.nx; i++)
                {
                    temp[j][i] = wsp * (temp[j - 1][i - 1] - 2.0 * temp[j - 1][i] + temp[j - 1][i + 1]) + temp[j - 1][i];
                }
            }
            return temp;
        }       
    }
}
