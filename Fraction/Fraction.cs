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

        public static Fraction operator *(Fraction f1, Fraction f2) => new Fraction(f1.num * f2.num, f1.den * f2.den);

        public override bool Equals(object obj)
        {
            if (!(obj is Fraction item))
            {
                return false;
            }
            var tmp = (Fraction)obj;
            return tmp.den == this.den && tmp.num == this.num;
        }

        public override int GetHashCode()
        {
            return this.den.GetHashCode(); // errore del test ?
        }
    }
}
