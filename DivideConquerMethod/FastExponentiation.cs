using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivideConquerMethod
{
    public class FastExponentiation
    {
        public double Power(double num, int n)
        {
            if (n == 0)
                return 1;
            if (n == 1)
                return num;

            double t = Power(num, n/2);

            return t*t*Power(num, n%2);
        }
    }
}
