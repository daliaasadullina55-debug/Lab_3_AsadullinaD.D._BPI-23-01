using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3_AsadullinaD.D._БПИ_23_01
{
    public class Task4Calculation : Calculation
    {
        private double a;
        private double c;

        public double A { get => a; set => a = value; }
        public double C { get => c; set => c = value; }
        public double D { get; set; }

        public Task4Calculation(double a, double c, double d)
        {
            A = a;
            C = c;
            D = d;
        }

        public override double Calculate()
        {
            double sum = 0;
            for (int i = 0; i <= D; i++)
            {
                sum += Math.Pow(C + A, i);
            }
            Result = sum;
            return Result;
        }
    }
}
