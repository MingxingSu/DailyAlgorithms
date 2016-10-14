using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _70_ClimbingStairs
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            List<int> testData = new List<int>() {0,1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 ,100};

            foreach (var n in testData)
            {
                var now = DateTime.Now;
                var r = solution.ClimbStairsV2(n);

                Console.WriteLine("To reach top floor: the {0}th, ' there are {1} ways to climb, execution time :{2}ms", n,r, (DateTime.Now - now).TotalMilliseconds);
            }
            Console.Read();

            

        }
    }
    public class Solution
    {

        public int ClimbStairs(int n)
        {
            if (n > 1)
                return ClimbStairs(n - 1) + ClimbStairs(n - 2);
            return n;
        }

        public int ClimbStairsV2(int n)
        {
            if (n > 1)
            {
                int f0 = 0;
                int f1 = 1;
                int result = 0;
                for (int i = 1;i <= n;i++)
                {
                    result = f0 + f1;
                    f0 = f1;
                    f1 = result;
                }
                return result;
            }
            return n;
        }
    }
}
