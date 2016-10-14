using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _31_NextPermutation
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            int[] testData = new []{ 1, 2, 3};
            Console.WriteLine("Inputs: {0}", String.Join(",", testData));
            solution.NextPermutation(testData);
            Console.WriteLine("Next Permutation is : {0}", String.Join(",", testData));
            Console.WriteLine();


            testData = new[] { 1, 2, 2 };
            Console.WriteLine("Inputs: {0}", String.Join(",", testData));
            solution.NextPermutation(testData);
            Console.WriteLine("Next Permutation is : {0}", String.Join(",", testData));
            Console.WriteLine();

            testData = new[] { 3, 2, 1 };
            Console.WriteLine("Inputs: {0}", String.Join(",", testData));
            solution.NextPermutation(testData);
            Console.WriteLine("Next Permutation is : {0}", String.Join(",", testData));
            Console.WriteLine();

            testData = new[] { 1, 3, 2,1 }; //2,3,1->2,1,3
            Console.WriteLine("Inputs: {0}", String.Join(",", testData));
            solution.NextPermutationV2(testData);
            Console.WriteLine("Next Permutation is : {0}", String.Join(",", testData));
            Console.WriteLine();

            testData = new[] { 3, 1, 2 };
            Console.WriteLine("Inputs: {0}", String.Join(",", testData));
            solution.NextPermutation(testData);
            Console.WriteLine("Next Permutation is : {0}", String.Join(",", testData));
            Console.WriteLine();

            Console.Read();
        }
    }
    //Beat 57.45%
    public class Solution
    {
        //我的收获：1.如果想判断数组的升序，降序，就用相邻元素比较法，循环退出时，就是序列的趋势改变点位。
        //         2.扫描数组并查找比某目标值大或者小的数时，把比较条件放在循环条件里，循环体只是指针移动。这样更高效。如while (j > 0 && nums[j] <= nums[i - 1])j--，
        public void NextPermutation(int[] nums)
        {
            if (nums.Length < 2)
                return;
            int i = nums.Length - 1;
            int j = nums.Length - 1;
            while (i > 0 && nums[i] <= nums[i - 1]) i--;//make sure the [i..len-1] is in descending order;
            if (i == 0)
            {
                Reverse(nums,i,nums.Length -1);
                return;
            }
            while (j > 0 && nums[j] <= nums[i - 1]) j--;//Find the least bigger than nums[i-1];
            Swap(nums,j, i-1);
            Reverse(nums,i, nums.Length -1);//[i, len-1] is in descending order
        }

        private void Swap(int[] nums, int p, int q)
        {
            int t = nums[q];
            nums[q] = nums[p];
            nums[p] = t;
        }

        private void Reverse(int[] nums, int begin, int end)
        {
            for (int i = begin; i < (begin + end +1)/2; i++)
            {
                Swap(nums,i,begin + end -i);
            }
        }


        //优化
        public void NextPermutationV2(int[] nums)
        {
            if (nums.Length < 2)
                return;
            int i = nums.Length - 1;
            int j = nums.Length - 1;
            while (i > 0 && nums[i] <= nums[i - 1]) i--;//make sure the [i..len-1] is in descending order;
            if (i == 0)
            {
                Array.Sort(nums);
                return;
            }
            while (j > 0 && nums[j] <= nums[i - 1]) j--;//Find the least bigger than nums[i-1];
            Swap(nums, j, i - 1);
            Array.Sort(nums, i, nums.Length - i); //[i, len-1] is in descending order
        }


    }
}
