using System;
using Algorithms.Sort;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DailyAlgorithms.Tests.Sort
{
    [TestClass]
    public class TestQuickSort
    {
        [TestMethod]
        public void TestQuickSortMethod1()
        {
            int[] list = {2, 3, 4, 1, 7, 3, 8, 1100, 282828, 1, 20, 0};
            QuickSort quickSort = new QuickSort(list);
            Assert.IsTrue(quickSort.GetSortedListString() == "0,1,1,2,3,3,4,7,8,20,1100,282828");
        }

        [TestMethod]
        public void TestQuickSortMethod2()
        {
            int[] list = { 1,1,2,1 };
            QuickSort quickSort = new QuickSort(list);
            Assert.IsTrue(quickSort.GetSortedListString() == "1,1,1,2");
        }

        [TestMethod]
        public void TestQuickSortMethod3()
        {
            int[] list = { };
            QuickSort quickSort = new QuickSort(list);
            Assert.IsTrue(quickSort.GetSortedListString() == "");
        }
    }
}
