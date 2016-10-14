using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _198_HouseRobber
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            int[] testData = new[] { 2, 4, 6, 8, 10,3 };
            Console.WriteLine("Inputs: {0}", String.Join(",", testData));
            int sum = solution.Rob_V2(testData);
            Console.WriteLine("Max amount can rob : {0}", sum);
            Console.WriteLine();


            testData = new[] { 10,20,50,80,40,60 };
            Console.WriteLine("Inputs: {0}", String.Join(",", testData));
            sum= solution.Rob(testData);
            Console.WriteLine("Max amount can rob : {0}", sum);
            Console.WriteLine();

            testData = new[] { 20, 81, 25, 46, 60, 70 };
            Console.WriteLine("Inputs: {0}", String.Join(",", testData));
            sum = solution.Rob(testData);
            Console.WriteLine("Max amount can rob : {0}", sum);
            Console.WriteLine();

            Console.Read();

        }
    }
    public class Solution
    {
        /*
        Dynamic programming
        Bottom-up approach
        Since we cannot rob 2 adjacent houses, generally, we cannot rob house[n] and house [n-1] at the same night
       
        So the basic idea is to see if house[n-1] has been robbed            
            If house[n-1] hasn't been robbed, then the optimal approach should be robbedmoney(n-2)+nums[n]
            If house[n-1] has been robbed, then the optimal approach should be max{robbedmoney(n-1), robbedmoney(n-2)+nums[n]}
         * 
        */

        public int Rob(int[] nums)
        {
            int len = nums.Length;
            if (len < 1)
                return 0;
            int[] dp = new int[len];

            for (int i = 0; i < len; i ++)
            {
                //处理起始时不适合状态转移方程的情况
                if (i == 0) dp[i] = nums[i];
                else if (i == 1)
                {
                    dp[i] = Math.Max(nums[i], nums[i - 1]);
                }
                else 
                    dp[i] = Math.Max(dp[i-2]+nums[i],dp[i-1]);//边界是i-2

            }
            return dp[len-1];
        }

        public int Rob_V2(int[] nums)
        {
            int len = nums.Length;
            if (len == 1)
            {
                return nums[0];
            }
            int curNotTaken = 0;
            int curTaken = 0;
            int robNot = 0;
            int rob = 0;
            for (int i = 0; i < len; i++)
            {
                curNotTaken = Math.Max(robNot, rob);//这次不抢，显然上次抢了
                curTaken = robNot + nums[i];//上次没抢的总收益+这次的抢的

                robNot = curNotTaken;
                rob = curTaken;
            }
            return Math.Max(curNotTaken, curTaken);
        }
    }
}
