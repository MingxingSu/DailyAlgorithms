using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _283_MoveZeros
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            int[] nums = new[] { 0, 1, 0, 3, 12 };
            Console.WriteLine("Input:{0} ", String.Join(",",nums));
            s.MoveZeroes(nums);
            Console.WriteLine("Result:{0} ", String.Join(",", nums));

            Console.Read();
        }
    }
    public class Solution
    {
        //Beat 70%
        public void MoveZeroes(int[] nums)
        {
            int i = 0;
            int len = nums.Length;
            while (i < len)
            {
                int k = i;
                while (k < len && nums[k] != 0) k++;
                int j = k + 1;
                while (j < len && nums[j] == 0) j++;
                if (j < len && k < len)
                    Swap(nums, k, j);
                else 
                    break;

                i = k+1;
            }
        }
        private void Swap(int[] nums, int i, int j)
        {
            int temp = nums[j];
            nums[j] = nums[i];
            nums[i] = temp;
        }
    }
}
