using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3_AsadullinaD.D._БПИ_23_01
{
    public class Task5Calculation : Calculation
    {
        private double x;
        private double y;
        private double t;
        private double f;
        private int n;
        private int k;

        public double X { get => x; set => x = value; }
        public double Y { get => y; set => y = value; }
        public double T { get => t; set => t = value; }
        public double F { get => f; set => f = value; }
        public int N { get => n; set => n = value; }
        public int K { get => k; set => k = value; }

        public Task5Calculation(double x, double y, double t, double f, int n, int k)
        {
            X = x;
            Y = y;
            T = t;
            F = f;
            N = n;
            K = k;
        }

        public override double Calculate()
        {
            double sum = 0;

            for (int i = 1; i <= N; i++)
            {
                for (int j = 1; j <= K; j++)
                {
                    double chislitel = Math.Pow(t * x, i) + Math.Pow(f * y, j);
                    double znamenatel = t * i * j;

                    if (znamenatel != 0)
                    {
                        sum += chislitel / znamenatel;
                    }
                }
            }

            Result = sum;
            return Result;
        }
    }
}
