using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fraction.Test
{
    [TestFixture]
    public class TapFrac{
        private static readonly Fraction F1 = new Fraction(1, 2);
        private static readonly Fraction F2 = new Fraction(1, 6);
        private readonly Fraction _f3 = F1 * F2;


        [Test]
        public void Moltip(){
            Assert.That(_f3.num, Is.EqualTo(1));
            Assert.That(_f3.den, Is.EqualTo(12));
        }


        [Test]
        public void Eq()
        {
            Assert.That(F1.Equals(new Fraction(1,2)),Is.EqualTo(true));
        }

    }
}
