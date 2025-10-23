using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3_AsadullinaD.D._БПИ_23_01
{
    public class Task1Calculation : Calculation
    {
        private double a;
        private double f;

        public double A { get => a; set => a = value; }
        public double F { get => f; set => f = value; }

        public Task1Calculation(double a, double f)
        {
            A = a;
            F = f;
        }

        public override double Calculate()
        {
            Result = Math.Sin(F * A);
            return Result;
        }
    }
}
