using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _28_Implement_strStr
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution solution= new Solution();
            List<string> testData = new List<string>() { "mississippi", "a", "Max", "apple", "ccabcddcbafgabc" };
            string needle = "issipi";
            foreach (var s in testData)
            {
                Console.WriteLine("we found the needle: '{0}' at the palace:'{1}' in heystack :{2} , curence :{1}", needle, solution.StrStr(s,needle),s);
            }
            Console.Read();

        }

    }
    //打败了78.48%的人
    public class Solution
    {
        public int StrStr(string haystack, string needle)
        {
            int pos = -1;
            if (String.IsNullOrEmpty(haystack))
            {
                //同时为空字符串时
                if (String.IsNullOrEmpty(needle))
                {
                    pos = 0;
                }
                return pos;
            }
            //处理needle长过haystack时
            if (haystack.Length < needle.Length)
                return pos;

            //定义指针
            int start = 0;
            int end = haystack.Length - 1;
            int needleLen = needle.Length;
            
            //用于不能完全匹配时的回溯
            int matchPoint = -1;
            bool everMatched = false;

            while (start <= end)
            {
                int i = 0;

                while (start <= end && i < needleLen)//切记要判断外层循环条件是否仍然成立
                {
                    //比较
                    if (needle[i] == haystack[start])
                    {
                        if (!everMatched)//第一次match时，记录match点的坐标
                        {
                            matchPoint = start;
                            everMatched = true;
                        }

                        i++;
                        start++;
                    }
                    else if (start > 0 && everMatched)//没能全部match,此时恢复start指针到match point
                    {
                        start = matchPoint;
                        everMatched = false;

                        break;
                    }
                    else
                        break;                  
                }
                //needle找到啦
                if (i == needleLen)
                {
                    pos = start -i;
                    break;
                }

                start++;
            }

            return pos;
        }
    }
}
