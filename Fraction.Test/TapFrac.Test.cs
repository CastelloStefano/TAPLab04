using System;
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
moltiplicare 42/1 per 0 produca 0
dividere 42/1 per 0 sollevi un'eccezione
0/1 sia uguale a 0/22
1/2 sia uguale a 2/4

l'intero 42 sia implicitamente convertibile in 42/1
l'intero 0 sia implicitamente convertibile in 0/1
la conversione esplicita di 42/1 abbia successo e restituisca l'intero 42
la conversione esplicita di 42/11 sollevi un'eccezione
*/


    [TestFixture]
    public class TapFrac
    {
        private Fraction _f1, _f2, _f3, _f4, _f5, _f6;

        [SetUp]
        protected void SetUp(){
            _f1 = new Fraction(1, 2);
            _f2 = new Fraction(1, 6);
            _f3 = _f1 * _f2; // [1/12]
            _f4 = _f1 + _f2; // [2/3]
            _f5 = _f1 - _f2; // [1/3]
            _f6 = _f1 / _f2; // [3/1]:[3]
        }

        //costruire una frazione col denominatore uguale a zero sollevi un'eccezione
        [Test]
        //[ExpectedException(typeof(DivideByZeroException))]
        public void NotZeroDen(){
            //Fraction f = new Fraction(1, 0);
            Assert.That(() => new Fraction(1,0), Throws.TypeOf(typeof(DivideByZeroException)));

        }

        [TestCase(1,2)]
        public void Eq(int n, int d){
            Assert.That(_f1.Equals(new Fraction(n,d)),Is.EqualTo(true));
        }

        [TestCase(2,5,10)]
        [TestCase(2,3,6)]
        [TestCase(2,4,4)]
        public void Mcm(int n, int d, int res){
            Assert.That(Fraction.Mcm(n,d), Is.EqualTo(res));
        }

        [Test]
        public void Sub(){
            Assert.That(_f5.Equals(new Fraction(1,3)));
        }

        [TestCase(33,42,111,8,44,777)]
        public void Div(int n1,int d1,int n2,int d2,int n3,int d3){
            Assert.That(new Fraction(n1,d1)/new Fraction(n2,d2), Is.EqualTo(new Fraction(n3,d3)));
        }

        [Test]
        public void Sum(){
            Assert.That(_f4.Equals(new Fraction(2,3)));
        }

        [Test]
        public void Moltip(){
            Assert.That(_f3, Is.EqualTo(new Fraction(1, 12)));
        }

        [TestCase(12,2,"6")]
        [TestCase(12, 5, "12/5")]
        [TestCase(24, 10, "12/5")]
        [TestCase(22, -11, "-2")]
        public void Print_Tostring(int n, int d, string r){
            Assert.That(new Fraction(n,d).ToString(), Is.EqualTo(r));
        }
    }
}
