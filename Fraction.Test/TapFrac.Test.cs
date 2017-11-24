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
        [Test]
        public void moltTest(){
            Fraction F1 = new Fraction(1, 2);
            Fraction F2 = new Fraction(1, 6);
            Fraction F3 = F1 * F2;
            Assert.That(F3.num, Is.EqualTo(1));
            Assert.That(F3.den, Is.EqualTo(12));
        }
    }
}
