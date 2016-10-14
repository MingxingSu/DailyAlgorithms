using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _30_SubstringWithConcatenationOfAllWords
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            PerformanceTest test = new PerformanceTest();
            test.PerformanceTestMethod1();

            Solution s = new Solution();

            string str = "barfoothefoobarman";
            string[] words = {"foo", "bar"};

            var indices = s.FindSubstring(str, words);
            Console.WriteLine("Input Str:{0};  Words:{1} ;" + Environment.NewLine + " Indice:{2}",
                str,
                String.Join(",", words),
                string.Join(",", indices));

            str = "wordgoodgoodgoodbestword";
            words = new string[] {"word", "good", "best", "good"};

            indices = s.FindSubstring(str, words);
            Console.WriteLine("Input Str:{0};  Words:{1} ;" + Environment.NewLine + " Indice:{2}",
                str,
                String.Join(",", words),
                string.Join(",", indices));

            str = "barfoofoobarthefoobarman";

            words = new string[] {"bar", "foo", "the"};

            indices = s.FindSubstring(str, words);
            Console.WriteLine("Input Str:{0};  Words:{1} ;" + Environment.NewLine + " Indice:{2}",
                str,
                String.Join(",", words),
                string.Join(",", indices));

            str = "a";

            words = new string[] {"a"};

            indices = s.FindSubstring(str, words);
            Console.WriteLine("Input Str:{0};  Words:{1} ;" + Environment.NewLine + " Indice:{2}",
                str,
                String.Join(",", words),
                string.Join(",", indices));

            str = "abaababbaba";

            words = new string[] {"ab","ba","ab","ba"};

            indices = s.FindSubstring(str, words);
            Console.WriteLine("Input Str:{0};  Words:{1} ;" + Environment.NewLine + " Indice:{2}",
                str,
                String.Join(",", words),
                string.Join(",", indices));



            Console.Read();
        }
    }

    public class Solution
    {

        //思路：Hash是用来比较的绝佳选择，而为这个问题，words的位置不固定，是变化的，给查找和匹配带来了挑战。
        //因此如果能把变化封装为不变，就能利用hashtable的特点到达快速查找的目的。所以，我们把word的每个位置的字符相加，得出的和，作为一个哈希项，用以匹配字符串。
        //rouping by different position. For example, dict = ["abc", "def"], then our hash array is ['a' + 'd', 'b' + 'e', 'c' + 'f'].
        //Given a str "123456", its hash is ['1' + '4', '2' + '5', '3' + '6']. Then compare this hash array with standard dict hash!
        public IList<int> FindSubstring(string s, string[] words)
        {
            IList<int> positions = new List<int>();
            if (!string.IsNullOrEmpty(s))
            {
                if (words != null && words.Length > 0)
                {
                    int strLen = s.Length;
                    int wordLen = words[0].Length;
                    int end = strLen - wordLen * words.Length + 1; //Index不可能大于end，因为end以后的元素总数不够一次words concatenation

                    StringBuilder sb = new StringBuilder(s);

                    //Standard dict hash.
                    int[] standarDictHash = new int[wordLen];

                    //words的字典，方面检查某个word是否在字典中。
                    Hashtable dict = new Hashtable();
                    foreach (string w in words)
                    {
                        if (!dict.Contains(w))
                            dict.Add(w, 1);
                        else 
                            dict[w] = ((int) dict[w] + 1);

                        for (int i = 0; i < wordLen; i++)
                        {
                            standarDictHash[i] += w[i];//word的每个位置上的字对应字符加在一起的和是不变的！
                        }
                    }

                    for (int i = 0; i < end; i ++)
                    {
                        var wordsStr = sb.ToString(i, wordLen * words.Length);//截取一个完整words Concatenation
                        var tempHashs = GetWordsHashArray(dict, wordsStr, wordLen);
                        if (Check(tempHashs, standarDictHash))
                        {
                            positions.Add(i);
                        }
                    }
                }
            }

            return positions;
        }

        private int[] GetWordsHashArray(Hashtable dict,string wordsStr, int wordLen)
        {
            int[] results = new int[wordLen];

            if (wordsStr.Length >= wordLen)
            {
                StringBuilder sb = new StringBuilder(wordsStr);
                //检查每个word是否在字典中
                for (int i = 0; i < wordsStr.Length - wordLen; i +=wordLen)
                {
                    if (!dict.ContainsKey(sb.ToString(i, wordLen)))
                        return results;
                }
                for (int i = 0; i < wordsStr.Length; i++)
                {
                    //计算所有words concatation的哈希值，用于后续比较
                    results[i % wordLen] += wordsStr[i];
                }
            }
            return results;
        }

        private bool Check(int[] sourceHashArray, int[] destiHashArray)
        {
            if (sourceHashArray.Length != destiHashArray.Length) return false;
            return !sourceHashArray.Where((t, i) => t != destiHashArray[i]).Any();//一一比较哈希值
        }

    }
}
