using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _27_RemoveElements
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            List<int> testData = new List<int>() { 4,5 };
            int val = 5;
            Console.WriteLine("Input Num Arrays: {0}, After Remove Element :{1}, The new array length is :{2}", String.Join(",",testData.ToArray()), val, s.RemoveElement(testData.ToArray(),val));

            testData = new List<int>() { 3, 3 };
            val = 3;
            Console.WriteLine("Input Num Arrays: {0}, After Remove Element :{1}, The new array length is :{2}", String.Join(",", testData.ToArray()), val, s.RemoveElement(testData.ToArray(), val));

            testData = new List<int>() { 3, 4 };
            val = 5;
            Console.WriteLine("Input Num Arrays: {0}, After Remove Element :{1}, The new array length is :{2}", String.Join(",", testData.ToArray()), val, s.RemoveElement(testData.ToArray(), val));

            testData = new List<int>() { 2,3,2,3 };
            val = 3;
            Console.WriteLine("Input Num Arrays: {0}, After Remove Element :{1}, The new array length is :{2}", String.Join(",", testData.ToArray()), val, s.RemoveElement(testData.ToArray(), val));


            testData = new List<int>() { 1, 2, 3, 4 };
            val = 1;
            Console.WriteLine("Input Num Arrays: {0}, After Remove Element :{1}, The new array length is :{2}", String.Join(",", testData.ToArray()), val, s.RemoveElement(testData.ToArray(), val));

            testData = new List<int>() { 1, 2, 3, 4 };
            val = 4;
            Console.WriteLine("Input Num Arrays: {0}, After Remove Element :{1}, The new array length is :{2}", String.Join(",", testData.ToArray()), val, s.RemoveElement(testData.ToArray(), val));

            testData = new List<int>() { 2, 3, 3 };
            val = 3;
            Console.WriteLine("Input Num Arrays: {0}, After Remove Element :{1}, The new array length is :{2}", String.Join(",", testData.ToArray()), val, s.RemoveElement(testData.ToArray(), val));
            
            Console.Read();
        }

    }
    
    //Given an array and a value, remove all instances of that value in place and return the new length.

    //Do not allocate extra space for another array, you must do this in place with constant memory.

    //The order of elements can be changed. It doesn't matter what you leave beyond the new length.

    //Example:
    //Given input array nums = [3,2,2,3], val = 3

    //Your function should return length = 2, with the first two elements of nums being 2.
    public class Solution
    {
        public int RemoveElement(int[] nums, int val)
        {
            #region 处理参数为空以及基本情况
            if (nums == null || nums.Length == 0)
                return 0;

            int len = nums.Length;

            if (len == 1)
            {
                if (nums[0] == val)
                {
                    nums = null;
                    len = 0;
                }
                return len;
            }
            #endregion
            
            #region 定义指针以及返回值
            int start = 0;
            int end = len - 1;
            int count = len;
            #endregion

            while (start < end)
            {

                while (start < end && nums[start] != val)//从前面开始找，跟目标元素相同的
                    start++;

                while (start < end && nums[end] == val) //从后面开始找，跟目标元素不同的
                {

                    end--;
                    count--;//找到了，并且有重复
                }

                //一个都没有找到
                if (start == len - 1)
                {
                    count = len;
                    break;
                }

                //元素全部相同
                if (end == 0)
                {
                    count = 0;
                    break;
                }

                //找到一对不同的值，可以互换
                if (nums[end] != nums[start])
                {
                    int temp = nums[end];
                    nums[end] = nums[start];
                    nums[start] = temp;
                    
                    count--;
                }

                //指针相遇了，而且此处是目标元素
                if (start == end && nums[start] == val)
                    count--;

                //更新指针
                start++;
                end--;
            }
            
            //处理最后一个元素
            if (start > 0 && start == end && nums[start] == val)
                count--;

            return count;
        }

    }
}
