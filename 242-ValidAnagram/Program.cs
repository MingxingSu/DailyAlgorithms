using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _242_ValidAnagram
{
    class Program
    {
        static void Main(string[] args)
        {
            string s="anagram";
            string t = "nagaram";
            bool isAnagram = new Solution().IsAnagram(s, t);
            Console.WriteLine("{0} and {1} are anagram:{2}" ,s,t,isAnagram);

            Console.Read();
        }
    }

    public class Solution
    {
        //引入一个数组作为字典，把字符当做数组下标，这样两个不同字符串的相同字符就能引用同一个下标，从而达到：以想反的方式操作同一个计数器啦。
        public bool IsAnagram(string s, string t)
        {
            if (s.Length != t.Length)
                return false;
            int count = 0;
            int[] map = new int[26];
            for (int i = 0; i < s.Length; i++)
            {
                if (++map[s[i]-'a'] == 1) count++;
                if (--map[t[i]-'a'] == 0) count--;
            }
            return count == 0;
        }

        //this is my initial soluton:思考如果把两个循环合并为一个循环里的两个分支，并共用同一个计数器。
        //一个分支负责原来循环的计数增加，一个负责负责原来第二个循环的计数减少。
        public bool IsAnagramV1(string s, string t)
        {
            Dictionary<char, int> dict = new Dictionary<char, int>(s.Length);
            foreach (char c in s)
            {
                if (dict.ContainsKey(c))
                    dict[c]++;
                else
                    dict[c] = 1;
            }
            foreach (char c in t)
            {
                if (dict.ContainsKey(c))
                    dict[c]--;
                else
                    return false;
            }
            foreach (var kv in dict)
            {
                if (kv.Value != 0)
                {
                    return false;
                }
            }
            return true;

        }

    }
}
