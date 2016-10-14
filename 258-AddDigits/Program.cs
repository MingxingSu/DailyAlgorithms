using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _258_AddDigits
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            int[] nums = new[] { 12,99,38,278,2345};

            foreach (int n in nums)
            {
                Console.WriteLine("Input:{0}, Digits:{1}", n, s.AddDigitsV2(n));
            }
            Console.Read();
        }
    }
    public class Solution
    {
        public int AddDigits(int num)
        {
            if (num < 10)
                return num;

            int sum = 0;
            while (num > 0)
            {
                sum += num%10;
                num /= 10;

                if (num ==0 && sum > 9)
                {
                    num = sum;
                    sum = 0;
                }
            }

            return sum;
        }

        //x % 9 = ( 2+ 3 + 4 + 5 + 6) % 9, note that x = 2* 10000 + 3 * 1000 + 4 * 100 + 5 * 10 + 6 So we have 23456 % 9 = (2 + 3 + 4 + 5 + 6) % 9，这是证明
        public int AddDigitsV2(int num)
        {
            if (num == 0) return 0;
            if (num % 9 == 0)return 9;//还是要从基本情况出发，得出规律
            return num % 9;
        }
    }
}
