using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_FindMedianTwoSortedArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numInts1 = new List<int>() { 1,3,9};
            List<int> numInts2 = new List<int>() { 2, 6, 7, 11};//1,2,3,6,7,9,11

            Console.WriteLine("The median element is : " + Solution.FindMedianSortedArrays(numInts1.ToArray(),numInts2.ToArray()));
            Console.Read();
        }
    }

    //There are two sorted arrays nums1 and nums2 of size m and n respectively. Find the median of the two sorted arrays.
    //The overall run time complexity should be O(log (m+n)).
    public class Solution
    {
        public static double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            int m = nums1.Length;
            int n = nums2.Length;
            int left = (m + n + 1)/2;
            int right = (m + n + 2)/2;

            return (GetKth(nums1, 0, nums2, 0, left) + GetKth(nums1, 0, nums2, 0, right))/2.0;
        }

        private static double GetKth(int[] A, int aStart, int[] B, int bStart, int k)
        {
            if (aStart > A.Length - 1) return B[bStart + k - 1];//A短
            if (bStart > B.Length - 1) return A[aStart + k - 1];//B短
            if (k == 1) return Math.Min(A[aStart], B[bStart]);

            int aMid = int.MaxValue, bMid = int.MaxValue;
            if (aStart + k / 2 - 1 < A.Length) aMid = A[aStart + k / 2 - 1];
            if (bStart + k / 2 - 1 < B.Length) bMid = B[bStart + k / 2 - 1];

            if (aMid < bMid)
                return GetKth(A, aStart + k / 2, B, bStart, k - k / 2);// Check: aRight + bLeft 
            else
                return GetKth(A, aStart, B, bStart + k / 2, k - k / 2);// Check: bRight + aLeft
        }
    }
}
