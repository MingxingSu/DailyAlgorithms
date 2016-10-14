using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _343_IntegerBreak
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            List<int> testData = new List<int>() {1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20};

            foreach (var n in testData)
            {
                Console.WriteLine("{0} 's max product which generated from break integers is :{1}", n,
                    Solution.IntergerBreak_DP(n));
            }
            Console.Read();
        }
    }

    public class Solution
    {
        //Given a positive integer n, break it into the sum of at least two positive integers and maximize the product of those integers. Return the maximum product you can get.

        //For example, given n = 2, return 1 (2 = 1 + 1); given n = 10, return 36 (10 = 3 + 3 + 4).

        //Note: you may assume that n is not less than 2. (n>=2)
        public static int IntegerBreak(int n)
        {

            if (n == 1)
            {
                return 0;
            }
            if (n == 2)
            {
                return 1;
            }
            if (n == 3)
            {
                return 2;
            }

            //int cnt_three = ceil((double)n/3.0);
            int cnt_three = n/3;
            int mod_three = n%3;
            if (mod_three == 0)
            {
                return (int) Math.Pow(3, cnt_three);
            }
            if (mod_three == 2)
            {
                return (int)Math.Pow(3, cnt_three) * 2;
            }

            return (int)Math.Pow(3, cnt_three - 1) * 4;
        }

        public static int IntergerBreak_DP(int n)
        {
            if (n == 0) return 0;
            if (n == 1) return 1;
            if (n == 2) return 1;
            if (n == 3) return 2;
            if (n == 4) return 4;


            int[] dp = new int[n+1];
            dp[0] = 0;
            dp[1] = 1;
            dp[2] = 1;
            dp[3] = 2;
            dp[4] = 4;

            for (int i = 5; i <= n; ++i)
            {
                dp[i] = 3*Math.Max(i - 3, dp[i - 3]);
            }
            return dp[n];
        }
    }
}
