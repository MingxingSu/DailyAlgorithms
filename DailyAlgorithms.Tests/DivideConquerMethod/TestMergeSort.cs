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
    public class TestMergeSort
    {
        [TestMethod]
        public void TestQuickSortMethod1()
        {
            int[] list1 = { 1,3,10,4,9,5,6,2,3,4,7,8};
            int[] expectedResult = { 1, 2, 3, 3,4, 4, 5, 6, 7, 8, 9, 10 };
            MergeSort quickSort = new MergeSort();
            Assert.IsTrue(Common.GetJoinedArrayString(quickSort.Sort(list1)) == 
                Common.GetJoinedArrayString(expectedResult));
        }
    }
}
