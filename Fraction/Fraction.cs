using System;

namespace Fraction
{
    public class Fraction
    {
        public int den, num;

        public Fraction(int num, int den)
        {
            if (den < 0)
            {
                den *= -1;
                num *= -1;
            }
            for (int i = Math.Min(num, den); i > 1; i--)
            {
                if (num % i == 0 && den % i == 0)
                {
                    num /= i;
                    den /= i;
                }
            }

            this.den = den;
            this.num = num;
        }

        public static int Mcm(int n, int d){
            if (n != d){
                for (int i = 2; i <= (n * d); i++)
                {
                    if (i % n == 0 && i % d == 0) return i;
                }
                return  (n * d);
            }
            return n;
        }

        public static Fraction operator *(Fraction f1, Fraction f2) => new Fraction(f1.num * f2.num, f1.den * f2.den);

        public static Fraction operator +(Fraction f1, Fraction f2)
        {
            int mcm = Mcm(f1.den, f2.den);
            return new Fraction(((mcm/f1.den)*f1.num)+((mcm / f2.den) * f2.num),mcm);
        }

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
            return (this.den.GetHashCode()+num.GetHashCode()).GetHashCode(); // Idea Giusta ?
        }
    }
}
