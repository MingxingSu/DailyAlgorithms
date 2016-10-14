using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _49_GroupAnagrams
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();

            string[] testData =
            {"eat", "tea", "tan", "ate", "nat", "bat"};
            var now = System.DateTime.Now;
            var resultStrList = solution.GroupAnagramsV2(testData);
            var now2 = System.DateTime.Now;
            foreach (IList<string> group in resultStrList)
            {
                Console.WriteLine(String.Join(",",group));
                Console.WriteLine("Total Seconds:"+(now2-now).TotalSeconds);
            }

            Console.Read();
        }
    }
    public class Solution
    {
        //Beat 83%，差异中求同，找到变量中的不变量，是这个算法的关键
        public IList<IList<string>> GroupAnagramsV2(string[] strs)
        {
            IList<IList<string>> wordsGroups = new List<IList<string>>();

            Hashtable htWords = new Hashtable();//使用Hashtable是因为它对字符串做key时效率较高，都是reference type，何况value还是List<string>
            foreach (string word in strs)
            {
                //先给单词排序，从而多个结果才能够合并一个相同字典项（
                String sortedWord = "";
                if (!String.IsNullOrEmpty(word)) 
                    sortedWord = String.Concat(word.OrderBy(c => c));

                List<string> wordGroup = new List<string>();
                if (!htWords.ContainsKey(sortedWord))
                {
                    wordGroup.Add(word);
                    htWords[sortedWord] = wordGroup;
                }
                else
                    ((List<string>)htWords[sortedWord]).Add(word);
            }

            foreach (DictionaryEntry entry in htWords)
            {
                var groupWord = entry.Value as List<string>;
                if (groupWord != null)
                    wordsGroups.Add(groupWord.Count == 1 ? groupWord : groupWord.OrderBy(w => w).ToList());//对一组内多个结果的进行排序
            }
            return wordsGroups;
        }

        //这个思路是我的刚开始的想法，虽然实现了，但是效率太低，无法处理大量数据。
        [Obsolete]
        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            IList<IList<string>> wordsGroups = new List<IList<string>>();

            //把所有元素放入字典中，并记录出现次数
            Hashtable htWords = new Hashtable();
            foreach (string word in strs)
            {
                if (!htWords.ContainsKey(word)) htWords[word] = 0;
                else htWords[word] = ((int) htWords[word]) + 1;
            }
            
            //遍历整个单词列表
            foreach (DictionaryEntry dictEntry in htWords)
            {
                String word = (string)dictEntry.Key;
                bool hasJoinedGroup = wordsGroups.Any(wordGroup => wordGroup.Contains(word));
                if (!hasJoinedGroup)
                {
                    //给单词每一个字符排序，升序
                    String sortedWord = "";
                    if (!String.IsNullOrEmpty(word)) sortedWord = String.Concat(word.OrderBy(c => c));
                    
                    //生成该单词的全部变形单词
                    List<string> wordList = GenerateTransformedWordsList(sortedWord);

                    //过滤以及添加可行解
                    var group = wordList.Where(w => htWords.ContainsKey(w)).ToList();
                    wordsGroups.Add(group);
                }
            }
            return wordsGroups;
        }

        [Obsolete]
        private List<string> GenerateTransformedWordsList(string word)
        {
            var wordlist = new List<string>();
            if(String.IsNullOrEmpty(word) || string.IsNullOrWhiteSpace(word)) return wordlist;
            if (word.Length == 1)
            {
                wordlist.Add(word);
                return wordlist;
            }

            StringBuilder sb = new StringBuilder();
            List<string[]> tempList = new List<string[]>();
            for (int i = 0; i < word.Length; i++)
            {
               for (int j = 0; j < word.Length; j++)
                {
                    if (j != i)
                    {
                        sb = new StringBuilder(word);
                        StringBuilder tempBuilder = new StringBuilder(sb[i].ToString());
                        int back, front;
                        if (i < j)
                        {
                            back = j;
                            front = i;
                        }
                        else
                        {
                            back = i;
                            front = j;
                        }

                        tempList.Add(new[] { tempBuilder.Append(sb[j]).ToString(), sb.Remove(back,1).Remove(front,1).ToString() });
                    }
                }
            }
            foreach (var wordParts in tempList)
            {
                string prefix = wordParts[0];
                string charsPool = wordParts[1];
                if (String.IsNullOrEmpty(charsPool))
                {
                    wordlist.Add(prefix);
                    continue;
                }

                List<string> wordsRecursive = GenerateTransformedWordsList(charsPool);

                foreach (string s in wordsRecursive)
                {
                    if(!string.IsNullOrEmpty(s))
                        wordlist.Add(prefix+s);
                }
            }
            return wordlist;
        }
    }
}
