using System;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace Fraction.Test
{
    [TestFixture]
    public class TapFrac
    {
        private Fraction _f1, _f2, _f3, _f4, _f5;

        [SetUp]
        protected void SetUp(){
            _f1 = new Fraction(1, 2);
            _f2 = new Fraction(1, 6);
            _f3 = _f1 * _f2; // [1/12]
            _f4 = _f1 + _f2; // [2/3]
            _f5 = _f1 - _f2; // [1/3]
        }

        [TearDown]
        protected void TearDown(){
            _f1 =_f2 = _f3 = _f4 = _f5 = null; 
        }

        [TestCase(12)]
        [TestCase(15)]
        [TestCase(0)]
        public void ImplConv(int num)
        {
            Fraction f = num;
            Assert.That(f,Is.EqualTo(new Fraction(num,1)));
        }

        [TestCase(20)]
        [TestCase(10)]
        public void ExplConv(int n)
        {
            int i = (int) new Fraction(n);
            Assert.That(i, Is.EqualTo(n));
        }

        [Test]
        public void WrongConv()
        {
            Assert.That(() => (int) new Fraction(3,5),Throws.TypeOf<ArithmeticException>());
        }

        [Test]
        public void NotZeroDen(){
            Assert.That(() => new Fraction(1,0), Throws.TypeOf(typeof(DivideByZeroException)));
        }

        [Test]
        public void NotZeroDenDiv()
        {
            Assert.That(() => new Fraction(1, 10)/new Fraction(0,3), Throws.TypeOf(typeof(DivideByZeroException)));
        }

        [TestCase(2, 4, 1, 2)]
        [TestCase(1, -1, -1, 1)]
        public void Normaliz(int n1, int d1, int n2, int d2){ 
            Assert.That(new Fraction(n1, d1), Is.EqualTo(new Fraction(n2,d2)));
        }

        [TestCase(2,2,1)]
        [TestCase(4,4,1)]
        [TestCase(-3,-3,1)]
        public void NoDen(int n1, int n2, int d2)
        {
            Assert.That(new Fraction(n1), Is.EqualTo(new Fraction(n2, d2)));
        }

        [TestCase(1,2,20,40)]
        [TestCase(0,1,0,23)]
        public void Eq(int n1, int d1, int n2, int d2){
            Assert.That(new Fraction(n1,d1).Equals(new Fraction(n2,d2)));
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
