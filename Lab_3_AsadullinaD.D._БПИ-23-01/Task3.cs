using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3_AsadullinaD.D._БПИ_23_01
{
    public class Task3Calculation : Calculation
    {
        private double a;
        private double b;
        private double c;
        private double d;

        public double A { get => a; set => a = value; }
        public double B { get => b; set => b = value; }
        public double C { get => c; set => c = value; }
        public double D { get => d; set => d = value; }

        public Task3Calculation(double a, double b, double c, double d)
        {
            A = a;
            B = b;
            C = c;
            D = d;
        }

        public override double Calculate()
        {
            Result = C * Math.Pow(A, 2) + D * Math.Pow(B, 2);
            return Result;
        }
    }
}
