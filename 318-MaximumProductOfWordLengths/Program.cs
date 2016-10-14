using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _318_MaximumProductOfWordLengths
{
    class Program
    {
        static void Main(string[] args)
        {
            PerformanceTest test = new PerformanceTest();
            test.PerformanceTestMethod1();

            Solution s = new Solution();


            string[] words = { "a", "ab", "abc", "d", "cd", "bcd", "abcd" };

            var max = s.MaxProduct(words);
            Console.WriteLine("Words:{0} ;" + Environment.NewLine + " MaxProduct:{1}",
                String.Join(",", words),
               max);

            words = new []{ "foo", "bar" };

            max = s.MaxProduct(words);
            Console.WriteLine("Words:{0} ;" + Environment.NewLine + " MaxProduct:{1}",
                String.Join(",", words),
               max);




            Console.Read();
        }
    }
    public class Solution
    {
        public int MaxProduct(string[] words)
        {
            int len = words.Length;
            int[] bitsTable = new int[len];
            for (int i = 0; i < len; i++)
            {
                string word = words[i];
                foreach (char t in word)
                    bitsTable[i] |= 1 << (t - 'a');
            }
            var max = 0;
            for (var i = 0; i <len- 1; i++)
            {
                var s1 = words[i];
                for (var j = i + 1; j <len; j++)
                {
                    var s2 = words[j];
                    var tempMax = s1.Length * s2.Length;
                    if ((bitsTable[i] & bitsTable[j]) ==0 && tempMax > max)
                    {
                        max = tempMax;
                    }
                }
            }
            return max;
        }
        
        //检查有无共通字母，能够容易联想到位运算里的&操作。其实就是把每个字母映射到位表中，两个单词中非空位肯定不会相同。此时就找到了一个候选对。那问题是如何把单词映射到位表？转换为整数，再移位，移动的位数就是字符的相对整数值（'a'=97, 是1,b就是2
        private bool HasCommonLetter(string s1, string s2)
        {
            Dictionary<char, bool> dict = new Dictionary<char, bool>();
            foreach (char c in s1)
            {
                if (!dict.ContainsKey(c)) dict[c] = true;
            }
            foreach (char c in s2)
            {
                if (dict.ContainsKey(c)) return true;
            }
            return false;
        }


    }
}
