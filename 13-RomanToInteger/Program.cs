using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13_RomanToInteger
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            List<string> testData0 =
                new List<string>() {"MCDLXXVI","IV", "V", "VII", "XXIX", "LV", "XCIX"};

            foreach (string s in testData0)
            {

                Console.WriteLine("Input Roman:{0}, After convert, the Integer is {1}", s, Solution.RomanToInt(s));
            }
            Console.Read();
        }
    }

    public class Solution
    {
        //Given a roman numeral, convert it to an integer.
        //Input is guaranteed to be within the range from 1 to 3999.

        private static readonly Dictionary<char, int> RomanCharsDict;

        static Solution()
        {
            RomanCharsDict = new Dictionary<char, int>
            {
                {'I', 1},
                {'V', 5},
                {'X', 10},
                {'L', 50},
                {'C', 100},
                {'D', 500},
                {'M', 1000}
            };
        }

        //"MCDLXXVI"
        //1000 100 500 50 10 10 5 1
        public static int RomanToInt(string s)
        {
            if (string.IsNullOrEmpty(s))
                return 0;
            if (s.Length == 1)
                return RomanCharsDict[s[0]];

            int i = 0;
            int len =s.Length - 1;
            int romanInt = RomanCharsDict[s[len]];

            while (i < len )
            {
                if (RomanCharsDict[s[i]] >= RomanCharsDict[s[i + 1]]) 
                {
                    romanInt += RomanCharsDict[s[i]];
                }
                else
                {
                    romanInt -= RomanCharsDict[s[i]];
                }
                i++;
            }

            return romanInt;

        }
    }
}
