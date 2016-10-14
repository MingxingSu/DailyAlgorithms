using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _75_SortColors
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            var data = new[] {0,2,1};
            Console.WriteLine("Input Data: {0}", string.Join(",", data));
            s.SortColors(data);
            Console.WriteLine("Sorted:{0}",string.Join(",",data));

            data = new[] {1,0,0,0,0,0,0 };
            Console.WriteLine("Input Data: {0}", string.Join(",", data));
            s.SortColors(data);
            Console.WriteLine("Sorted:{0}", string.Join(",", data));
            Console.Read();
        }
    }
    //    Given an array with n objects colored red, white or blue, sort them so that objects of the same color are adjacent, with the colors in the order red, white and blue.

    //Here, we will use the integers 0, 1, and 2 to represent the color red, white, and blue respectively.

    //Note:
    //You are not suppose to use the library's sort function for this problem.
    public class Solution
    {
        public void SortColors(int[] nums)
        {
            if (nums == null || nums.Length == 0) return;
            int l = 0, r = nums.Length - 1;
            Sort(nums, ref l, r, 0);
            while (l < r && nums[l] == 0) { l++; }//注意：此时当前指针指向的值可能仍然为0（红色）
            Sort(nums, ref l, nums.Length - 1, 1);
        }
        private void Sort(int[] nums, ref int l, int r, int color)
        {
            while (l < r)
            {
                while (l < r && nums[l] == color) { l++; }
                while (l < r && nums[r] != color) { r--; }
                if (l < r)//注意：指针更新是在这个条件内和Swap一起是一组事务操作
                {
                    Swap(nums, l, r);
                    l++;
                    r--;
                }
            }
        }
        private void Swap(int[] nums, int i, int j)
        {
            nums[i] ^= nums[j];
            nums[j] ^= nums[i];
            nums[i] ^= nums[j];
        }
    }
}
