using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _345_ReverseVowels_of_String
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> testData = new List<string>() { "apple", "", "a", "Max", "hello", "abc", "ccabcddcbafgabc" };

            foreach (var s in testData)
            {
                Console.WriteLine("{0} 's reversed Vowels  is :{1}", s, Solution.ReverseVowels(s));
            }
            Console.Read();
        }
    }
    public class Solution
    {
        //Write a function that takes a string as input and reverse only the vowels of a string.

        //Example 1:
        //Given s = "hello", return "holle".

        //Example 2:
        //Given s = "leetcode", return "leotcede".
        public static string ReverseVowels(string s)
        {
            if (string.IsNullOrEmpty(s))
                return s;

            int len = s.Length;

            if (len == 1)
                return s;

            var sArray = s.ToCharArray();


            //首位交换
            int i = 0, j = len - 1;

            while (i < j)
            {
                if (IsVowel(s[i]))
                {
                    if (IsVowel(s[j]))
                    {
                        char temp = sArray[j];
                        sArray[j] = sArray[i];
                        sArray[i] = temp;
                        i++;
                        j--;
                    }
                    else
                    {
                        j--;
                    }
                }
                else
                {
                    i++;
                }
            }
            return new string(sArray);
        }

        private static bool IsVowel(char c)
        {
            char[] vowels = new[] {'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U'};
            return vowels.Contains(c);
        }

    }
}
