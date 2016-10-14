using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _69_Sqrt
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> testData = new List<int>() {2147395599, int.MaxValue, 1529170222,1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20,98,100, 100000000 };

            foreach (var n in testData)
            {
                var now = DateTime.Now;
                var r = Solution.MySqrt(n);

                Console.WriteLine("{0} 's sqrt is :{1}, execution time :{2}ms", n,r, (DateTime.Now - now).TotalMilliseconds);
            }
            Console.Read();

        }
    }
    public class Solution
    {
        //Beat 55.71%
        public static int MySqrt(int x)
        {
            const int sqrtMaxInt = 46340;
            if (x < 0) return 0;
            if (x < 2) return x;
            if (x < 4) return 1;

            int n = x / 2 > sqrtMaxInt ? sqrtMaxInt : x / 2; //防止溢出
            while (true)
            {
                int temp = n * n;
                if (temp > x)
                {
                    n /= 2;
                    continue;
                }
                if (temp == x) return n;
                if (temp < x) 
                {
                    int start = n, end = 2*n > sqrtMaxInt ? sqrtMaxInt : 2*n;
                    while (start < end)
                    {
                        int mid = (start + end)/2;
                        int tempSum = mid*mid;
                        if (tempSum > 0 && tempSum < x) start = mid + 1;
                        else end = mid;
                        if (tempSum == x) return mid;
                    }
                    if (end > sqrtMaxInt) return sqrtMaxInt;
                    if (start*start > x) return start - 1;
                    return start;
                }
            }
        }
    }
}
