using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace Fraction.Test
{

    /*TODO Test che verifica che:
     * Test che verifica che:

costruire un oggetto con numeratore=2 e denominatore=4 produca una frazione il cui numeratore è 1 e denominatore 2 (in altre parole, verificare che la frazione venga normalizzata)
costruire un oggetto con numeratore=1 e denominatore=-1 produca una frazione il cui numeratore è -1 e denominatore=1
sommare 1/2 e 2/5 produca 9/10
sottrarre 33/7 da 4 produca -5/7
moltiplicare 1/11 e 11 produca 1
dividere 33/42 per 111/8 produca 44/777
moltiplicare 42/1 per 0 produca 0
dividere 42/1 per 0 sollevi un'eccezione
0/1 sia uguale a 0/22
1/2 sia uguale a 2/4
la rappresentazione in stringa di 11/5 sia "11/5"
la rappresentazione in stringa di 22/11 sia "2"
la rappresentazione in stringa di 22/-11 sia "-2"
l'intero 42 sia implicitamente convertibile in 42/1
l'intero 0 sia implicitamente convertibile in 0/1
la conversione esplicita di 42/1 abbia successo e restituisca l'intero 42
la conversione esplicita di 42/11 sollevi un'eccezione
*/


    [TestFixture]
    public class TapFrac{
        private static readonly Fraction F1 = new Fraction(1, 2);
        private static readonly Fraction F2 = new Fraction(1, 6);
        private readonly Fraction _f3 = F1 * F2; // [1/12]
        private readonly Fraction _f4 = F1 + F2; // [2/3]
        private readonly Fraction _f5 = F1 - F2; // [1/3]
        private readonly Fraction _f6 = F1 / F2; // [3/1]:[3]



        //costruire una frazione col denominatore uguale a zero sollevi un'eccezione

        [Test]
        [ExpectedException(typeof(DivideByZeroException))]
        public void NotZeroDen()
        {
                Fraction f = new Fraction(1, 0);
        }

        [Test]
        public void Eq(){
            Assert.That(F1.Equals(new Fraction(1,2)),Is.EqualTo(true));
            Assert.That(F2.Equals(new Fraction(1, 6)), Is.EqualTo(true));
        }

        [Test]
        public void Mcm()
        {
            Assert.That(Fraction.Mcm(2,5), Is.EqualTo(10));
            Assert.That(Fraction.Mcm(2, 3), Is.EqualTo(6));
            Assert.That(Fraction.Mcm(2, 4), Is.EqualTo(4));
        }
        [Test]
        public void Sub()
        {
            Assert.That(_f5.Equals(new Fraction(1,3)));
        }

        [Test]
        public void Div()
        {
            Assert.That(_f6, Is.EqualTo(new Fraction(3,1)));
        }
        [Test]
        public void Sum(){
            Assert.That(_f4.Equals(new Fraction(2,3)));
        }

        [Test]
        public void Moltip(){
            Assert.That(_f3, Is.EqualTo(new Fraction(1, 12)));
        }

        [Test]
        public void Print_Tostring()
        {
            Assert.That(new Fraction(12,2).ToString(), Is.EqualTo("6"));
            Assert.That(new Fraction(12, 5).ToString(), Is.EqualTo("12/5"));
            Assert.That(new Fraction(24, 10).ToString(), Is.EqualTo("12/5"));
        }

    }
}
