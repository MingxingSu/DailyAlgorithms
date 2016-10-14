using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Sort;
using DivideConquerMethod;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DailyAlgorithms.Tests.DivideConquerMethod
{
    [TestClass]
    public class TestFastExponentiation
    {
        [TestMethod]
        public void TestFastExponentiationMethod()
        {
            FastExponentiation solutionFastExponentiation = new FastExponentiation();
            Assert.IsTrue(solutionFastExponentiation.Power(2,7)== 128.0, "True");
            Assert.IsTrue(solutionFastExponentiation.Power(1, 0) == 1.0, "True");
            Assert.IsTrue(solutionFastExponentiation.Power(5, 1) == 5.0, "True");
        }
    }
}
