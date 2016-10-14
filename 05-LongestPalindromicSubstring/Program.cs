using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_LongestPalindromicSubstring
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> testData = new List<string>() {"aaabaaaa", "iptmykvjanwiihepqhzupneckpzomgvzmyoybzfynybpfybngttozprjbupciuinpzryritfmyxyppxigitnemanreexcpwscvcwddnfjswgprabdggbgcillisyoskdodzlpbltefiz","aaaa","ccabcdcbafgabc", "ccabcddcbafgabc" };

            foreach (var s in testData)
            {
                Console.WriteLine("{0} 's longest palindrome sub string is :{1}", s, Solution.LongestPalindrome(s));    
            }
            Console.Read();
        }
    }
    public class Solution
    {
        public static string LongestPalindrome(string s)
        {
            //用来存储获取最终结果必备的几个数据
            int startIndex = 0;
            int endIndex = 1;
            int finalLongestPalindromLength = 0;

            //Suitation - 1 : 字符串为空，或者单元素
            if(String.IsNullOrEmpty(s) || s.Length ==1)
                return s;

            //Suitation -2 : 字符串只有两个元素
            if (s.Length == 2)
            {
                if (s[0] == s[1])
                {
                    return s;
                } 
                return String.Empty;
            }

            //Suitation -3 :当元素全部相同时，直接返回：这是为了绕开边界值处理
            bool isAllElementSame = true;
            for (int i = 0; i < s.Length - 1; i++) 
            {
                if (s[i] != s[i + 1])
                {
                    isAllElementSame = false;
                    break;
                }                
            }
            if (isAllElementSame)
            {
                return s;
            }

            //Suitation -4 :正常循环时
            for (int i = 1; i <= s.Length - 1; i++)
            {
                int low = 0;
                int hi = 1;
                int step = 1;
                int tempLongestPalindromLength = 0;

                //i.e: ABA
                while (i >= step && i <= s.Length - 1 - step && s[i - step] == s[i + step])//Bug# 左边界：当前面元素全部相同，而且i+step有相同值，但i-step空时；右边界：当前面元素全部相同，而且i-step有相同值，但i+step后空时， Fixed by Suitation - 3
                {
                    low = i - step;
                    hi = i + step;
                    tempLongestPalindromLength = 2 * step + 1;
                    if (tempLongestPalindromLength > finalLongestPalindromLength)
                    {
                        //更新起止坐标和最大长度
                        finalLongestPalindromLength = tempLongestPalindromLength;
                        startIndex = low;
                        endIndex = hi;
                    }

                    step = step +1;
                }

                //i.e: ABBA
                int step2 = 1;//定义两个步长是为了fix两种情况交叉：如aaabaaaa，当判断最后一个a时，如果共享步长，则会把最后一个a包含进去。
                while (i >= step2 - 1 && i <= s.Length - 1 - step2 && s[i - step2 + 1] == s[i + step2])
                {
                    low = i - step2 + 1;
                    hi = i + step2;
                    tempLongestPalindromLength = 2 * step2;

                    if (tempLongestPalindromLength > finalLongestPalindromLength)
                    {
                        //更新起止坐标和最大长度
                        finalLongestPalindromLength = tempLongestPalindromLength;
                        startIndex = low;
                        endIndex = hi;
                    }

                    step2 = step2 + 1;
                }
            }

            return s.Substring(startIndex, endIndex - startIndex + 1);
        }
    }
}
