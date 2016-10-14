using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12_IntegerToRoman
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //List<string> testData0 =
            //    new List<string>() {"MCDLXXVI", "IV", "V", "VII", "XXIX", "LV", "XCIX"};

            List<int> testData =
                new List<int>() {50,90,1476, 4, 5, 7, 29, 55, 99};
            foreach (int n in testData)
            {

                Console.WriteLine("Input Int:{0}, After convert, the Roman is: {1}", n, Solution.IntToRoman(n));
            }
            Console.Read();
        }
    }

    public class Solution
    {
        //Given a roman numeral, convert it to an integer.
        //Input is guaranteed to be within the range from 1 to 3999.

        private static readonly Dictionary<int, char> RomanCharsDict;

        static Solution()
        {
            RomanCharsDict = new Dictionary<int, char>
            {
                {1000,'M'},
                {500,'D'},
                {100,'C'},
                {50,'L'},
                {10,'X'},
                {5,'V'},
                {1,'I'}
            };
        }

        //"MCDLXXVI"
        //1000 100 500 50 10 10 5 1
        public static string IntToRoman(int num)
        {

            string numStr = "";

            //1476
            int mode = 1;
            while (num > 0)
            {
                int r = num%10;

                numStr = GetRoman(r, mode) + numStr;

                mode *= 10;
                num /= 10;
            }

            return numStr;
        }

        private static string GetRoman(int n, int mode)
        {

            if (mode == 1 && RomanCharsDict.ContainsKey(n))
            {
                return new String(RomanCharsDict[n], 1);
            }

            StringBuilder sb = new StringBuilder();

            if (n >= 1 && n <= 3)
            {
               sb.Append(RomanCharsDict[mode], n);
            }
            if (n > 5 && n < 9)
            {
                sb.Append(RomanCharsDict[mode*5]);
                sb.Append(RomanCharsDict[mode], n - 5);
            }
            else if (n == 4 || n == 9)
            {
                sb.Append(RomanCharsDict[mode]);
                sb.Append(RomanCharsDict[mode * (n + 1)]);
            }
            else if (n == 5)
            {
                sb.Append(RomanCharsDict[mode * n]);
            }
            return sb.ToString();
        }
    }
}


