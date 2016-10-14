using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms;
using Algorithms.Sort;

namespace DailyAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] list = { 2, 3, 4, 1, 7, 3, 8, 1100, 282828, 1, 20, 0 };
            Console.WriteLine(BinarySearch.BinSearch(list, list.Length -1, 7));

            Console.WriteLine(new QuickSort(list).GetSortedListString());
        }
    }
}
