using NUnit.Framework;

namespace Fraction.Test
{
    [TestFixture]
    public class TapFrac{
        private static readonly Fraction F1 = new Fraction(1, 2);
        private static readonly Fraction F2 = new Fraction(1, 6);
        private readonly Fraction _f3 = F1 * F2; // [1/12]
        private readonly Fraction _f4 = F1 + F2; // [2/3]

        [Test]
        public void Moltip(){
            Assert.That(_f3, Is.EqualTo(new Fraction(1, 12)));
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
        public void Sum(){
            Assert.That(_f4.Equals(new Fraction(2,3)));
        }


    }
}
