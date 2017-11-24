using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fraction
{
    public class Fraction
    {
        public int den, num;

        public Fraction(int num, int den)
        {
            this.den = den;
            this.num = num;
        }

        public static Fraction operator* (Fraction f1, Fraction f2)
        {
            return new Fraction(f1.num*f2.num,f1.den*f2.den);
        }


    }
}
