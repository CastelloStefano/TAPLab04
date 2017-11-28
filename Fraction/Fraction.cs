using System;

namespace Fraction
{
    public class Fraction
    {
        public readonly int Den;
        public readonly int Num;

        public Fraction(int num, int den)
        {
            if (den == 0)
                throw new DivideByZeroException();

            if (den < 0)
            {
                den *= -1;
                num *= -1;
            }
            for (int i = Math.Max(num, den); i > 1; i--)
            {
                if (num % i == 0 && den % i == 0)
                {
                    num /= i;
                    den /= i;
                }
            }
            Den = den;
            Num = num;
            
        }

        public Fraction(int n){
            Den = 1;
            Num = n;
        }

        public static implicit operator Fraction(int i)
        {
            return new Fraction(i);
        }

        public static explicit operator int(Fraction f)
        {
            if (f.Den == 1) return f.Num;
            throw new ArithmeticException();
        }

        public static int Mcm(int n, int d){
            if (n != d){
                for (int i = 2; i <= (n * d); i++) {
                    if (i % n == 0 && i % d == 0) return i;
                }
            }
            return n;
        }

        public static Fraction operator *(Fraction f1, Fraction f2) => new Fraction(f1.Num * f2.Num, f1.Den * f2.Den);

        public static Fraction operator +(Fraction f1, Fraction f2){
            int mcm = Mcm(f1.Den, f2.Den);
            return new Fraction(((mcm/f1.Den)*f1.Num)+((mcm / f2.Den) * f2.Num),mcm);
        }

        public static Fraction operator -(Fraction f1, Fraction f2)
        {
            int mcm = Mcm(f1.Den, f2.Den);
            return new Fraction(((mcm / f1.Den) * f1.Num) - ((mcm / f2.Den) * f2.Num), mcm);
        }

        public static Fraction operator /(Fraction f1, Fraction f2)
        {
            if (f2.Num != 0)
            {
                int den = f2.Num;
                int num = f2.Den;
                return new Fraction(f1.Num * num, f1.Den * den);
            }
            throw new DivideByZeroException();
        }

        public override string ToString()
        {
            if (Den == 1) return Num.ToString();
            return Num+"/"+Den;
        }

        public override bool Equals(object obj){
            if (!(obj is Fraction item)){
                return false;
            }
            var tmp = (Fraction)obj;
            if (Num == 0 && tmp.Num == 0) return true;
            return tmp.Den == Den && tmp.Num == Num;
        }

        public override int GetHashCode(){
            return (Den.GetHashCode()+Num.GetHashCode()).GetHashCode(); // Idea Giusta ?
        }
    }
}