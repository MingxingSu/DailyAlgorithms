using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_PalindromeNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numInts = new List<int>() { 1000021, 10201, 100021,- 2147447412, -1, 1, 9, 10, 11, 12, -11, -99, 78, 100, 110, 111, 121, -121, -1221, 1221 };
            
            foreach (int n in numInts)
            {
                Console.WriteLine("{0} is palindrome?: {1}", n, Solution.IsPalindromeV2(n));
            }
            Console.Read();
        }

        
    }

    public class Solution
    {
        //Solution - 1
        public static bool IsPalindrome(int x)
        {
            //处理负数以及边界值
            if ( x < 0 || x == int.MinValue || x == int.MaxValue)
            {
                return false;
            }
            if (x < 10)
            {
                return true;
            }
            return IsPalindromString(x.ToString());
        }

        private static bool IsPalindromString(string str)
        {
            for (int i = 0, j = str.Length - 1; i < j; i++ ,j-- )
            {
                if (str[i] != str[j])
                {
                    return false;
                }
            }
            return true;
        }

        //Solution - 2
        public static bool IsPalindromeV2(int x)
        {
            //处理负数以及边界值
            if (x < 0 || x == int.MinValue || x == int.MaxValue)
            {
                return false;
            }

            int reverseX = 0;
            int sourceValue = x;

            while (x > 0)
            {
                reverseX = 10 * reverseX + (x % 10); //此处是关键：根据上一次的计算结果和模运算结果来得出这次的结果

                x /= 10;
            }

            return reverseX == sourceValue;
        }

    }
}
