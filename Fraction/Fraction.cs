using System;

namespace Fraction
{
    public class Fraction
    {
        public readonly int Den;
        public readonly int Num;

        public Fraction(int num, int den){
            if (den < 0){
                den *= -1;
                num *= -1;
            }
            for (int i = Math.Min(num, den); i > 1; i--){
                if (num % i == 0 && den % i == 0){
                    num /= i;
                    den /= i;
                }
            }
            Den = den;
            Num = num;
        }

        public static int Mcm(int n, int d){
            if (n != d){
                for (int i = 2; i <= (n * d); i++) {
                    if (i % n == 0 && i % d == 0) return i;
                }
                return  (n * d);
            }
            return n;
        }

        public static Fraction operator *(Fraction f1, Fraction f2) => new Fraction(f1.Num * f2.Num, f1.Den * f2.Den);

        public static Fraction operator +(Fraction f1, Fraction f2){
            int mcm = Mcm(f1.Den, f2.Den);
            return new Fraction(((mcm/f1.Den)*f1.Num)+((mcm / f2.Den) * f2.Num),mcm);
        }

        public override bool Equals(object obj){
            if (!(obj is Fraction item)){
                return false;
            }
            var tmp = (Fraction)obj;
            return tmp.Den == this.Den && tmp.Num == this.Num;
        }

        public override int GetHashCode(){
            return (Den.GetHashCode()+Num.GetHashCode()).GetHashCode(); // Idea Giusta ?
        }
    }
}
