using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _344_ReverseString
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> testData = new List<string>() { "","a","Max", "hello", "abc", "apple", "ccabcddcbafgabc" };

            foreach (var s in testData)
            {
                Console.WriteLine("{0} 's reversed string is :{1}", s, Solution.ReverseString2(s));
            }
            Console.Read();
        }
    }
    public class Solution
    {
        public static string ReverseString(string s)
        {
            if (string.IsNullOrEmpty(s))
                return s;

            int len = s.Length;

            if (len == 1)
                return s;

            var sArray = s.ToCharArray();

            //首位交换
            for (int i = 0, j=len -1; i < j; i++,j--)
            {
                char temp = sArray[j];
                sArray[j] = sArray[i];
                sArray[i] = temp;
            }
            return new string(sArray);
        }

        public static string ReverseString2(string s)
        {
            if (string.IsNullOrEmpty(s))
                return s;

            int len = s.Length;
            var sArray = new char[len];

            //复制
            for (int i = 0, j = len - 1; i <len; i++, j--)
            {
                sArray[i] = s[j];
            }
            return new string(sArray);
        }
    }
}
