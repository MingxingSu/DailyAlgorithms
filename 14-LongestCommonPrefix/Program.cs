using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Sort;

namespace _14_LongestCommonPrefix
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> testData = new List<string>() { "ca", "a", "abc", "abcf", "abcgef" };

            Console.WriteLine("The longest common prefix is :" +Solution.LongestCommonPrefix(testData.ToArray()));

            List<string> testData1 = new List<string>() { "ab", "aa"};

            Console.WriteLine("The longest common prefix is :" + Solution.LongestCommonPrefix(testData1.ToArray()));

            List<string> testData2 = new List<string>() { "c", "c", "c" };

            Console.WriteLine("The longest common prefix is :" + Solution.LongestCommonPrefix(testData2.ToArray()));
            Console.Read();
        }
    }
    public class Solution
    {
        public static string LongestCommonPrefix(string[] strs)
        {
            if (strs == null || strs.Length == 0)
                return String.Empty;
            
            int arrayLength = strs.Length;
            if (arrayLength == 1)
                return strs[0];
            
            Dictionary<char,int> dict = new Dictionary<char,int>();

            //Find the shortest element
            string shortestStr = strs[0];
 
            foreach (string str in strs)
            {
                int length = str.Length;
                if (shortestStr.Length > length)
                {
                    shortestStr = str;
                }
            }

            int end = 0;
            bool faiedInMid = false;
            for (int i = 0; i < shortestStr.Length; i++)
            {
                foreach (string str in strs)
                {
                    if (str[i] != shortestStr[i])
                    {
                        faiedInMid = true;
                        break;
                    }
                }
                if(!faiedInMid)
                    end = i;
                else if (i == 0)//仅仅只匹配上了第一个字符
                    end = i - 1;
                else 
                    break;
                
            }

            return String.Empty == shortestStr
                ? String.Empty
                : shortestStr.Substring(0, end + 1);
        }
    }
}
