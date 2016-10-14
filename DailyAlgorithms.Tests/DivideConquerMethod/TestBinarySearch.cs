using System;
using Algorithms;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DailyAlgorithms.Tests
{
    [TestClass]
    public class TestBinarySearch
    {
        [TestMethod]
        public void TestBinarySearchMethod1()
        {
            int[] list = { 2, 3, 4, 1, 7, 3, 8, 1100, 282828, 1, 20, 0 };
            Assert.IsNotNull(BinarySearch.BinSearch(list, list.Length - 1, 7));
        }
        [TestMethod]
        public void TestBinarySearchMethod2()
        {
            int[] list = { 2, 3, 4, 1, 7, 3, 8, 1100, 282828, 1, 20, 0 };
            Assert.IsTrue(BinarySearch.BinSearch(list, list.Length - 1, 11) == -1);
        }

        [TestMethod]
        public void TestBinSearch2Method3()
        {
            int[] list = { 2, 3, 4, 10,16,50,66,99,101,200 };
            Assert.IsTrue(BinarySearch.BinSearch2(list, 0,9, 16) == 16);
        }
    }
}
