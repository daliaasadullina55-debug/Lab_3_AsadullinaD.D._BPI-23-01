using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3_AsadullinaD.D._БПИ_23_01
{
    public abstract class Calculation
    {
        private double _result;
        public double Result
        {
            get { return _result; }
            set { _result = value; }
        }

        public abstract double Calculate();

    }
}
