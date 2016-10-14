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
    public  class TestSumMaxSub
    {
        [TestMethod]
        public void TestSumMaxSubMethod1()
        {
            double[] list = { 2, -3, 1.5, -1, 3, -2, -3, 3};
            SumMaxSub sumMaxSub = new SumMaxSub();
            Assert.IsTrue(sumMaxSub.CalculateSumMaxSub(list)==3.5,"True");
        }
    }
}
