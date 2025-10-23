using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3_AsadullinaD.D._БПИ_23_01
{
    public class Task2Calculation : Calculation
    {
        private double a;
        private double b;
        private double f;

        public double A { get => a; set => a = value; }
        public double B { get => b; set => b = value; }
        public double F { get => f; set => f = value; }

        public Task2Calculation(double a, double b, double f)
        {
            A = a;
            B = b;
            F = f;
        }

        public override double Calculate()
        {
            Result = Math.Cos(F * A) + Math.Sin(F * B);
            return Result;
        }
    }
}
