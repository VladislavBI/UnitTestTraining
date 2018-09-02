using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTtTrain;

namespace Tests
{
    [TestFixture]
    public class MemCalculator_Tests
    {
        [Test]
        public void Sum_ByDefault_ReturnsZero()
        {
            MemCalculator calc = MakeCalc();

            int lastSum = calc.Sum();

            Assert.AreEqual(lastSum, 0);
        }

        [Test]
        public void Add_WhenCalled_ChangeSum()
        {
            MemCalculator calc = MakeCalc();

            calc.Add(1);
            int sum = calc.Sum();

            Assert.AreEqual(1, sum);
        }

        private static MemCalculator MakeCalc()
        {
            return new MemCalculator();
        }

        [TestCase(1, 2)]
        public void Add_AfterAdditional_ReturnsAditionalSum
            (int first, int second)
        {
            MemCalculator calc = new MemCalculator();

            calc.Add(first);
            calc.Add(second);

            Assert.AreEqual(calc.Sum(), 3);
        }
    }
}
