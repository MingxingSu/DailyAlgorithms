using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace _22_GenerateParentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> testData = new List<int>() { 0,1,2,3,4 };

            var s = new Solution();
            foreach (int n in testData)
            {
                Console.WriteLine("Parenthesis Count: {0} ;\r\nResults: {1}", n, String.Join("|", s.GenerateParenthesisWithHashTable(n)));
            }
            Console.Read();
        }
    }
    //Given n pairs of parentheses, write a function to generate all combinations of well-formed parentheses.

    //For example, given n = 3, a solution set is:

    //"((()))", "(()())", "(())()", "()(())", "()()()"
    public class Solution
    {
        public IList<string> GenerateParenthesis(int n)
        {
            List<string> resultList = new List<string>();
            if (n <= 0)
                return resultList;

            if (n == 1)
            {
                resultList.Add("()");
                return resultList;
            }

            resultList.Clear();
            char[] str = new char[2*n];

            int pos = 0;

            //此题难点在于递归式的提取，递归三要素：缩小问题规模(递），地基, 以小解大推到多米诺（归）
            Helper(ref resultList,n,n,ref str, pos);

            return resultList;
        }

        //递归法，注意传入参数有两个指针类型，我把它们称之为容器变量，以容纳计算结果，容易变量是简化计算过程
        private void Helper(ref List<string> list, int left, int right, ref char[] str, int pos)
        {
            if (left < 0 || right < left) 
                return;//此时)肯定多余),则跳过无效项：此处非常巧妙

            if (left == 0 && right == 0)//地基情况：必然是把找到的合格项加入返回列表里。
                list.Add(new string(str));

            if (left > 0)
            {
                str[pos] ='(';
                Helper(ref list, left - 1, right, ref str, pos + 1);//缩小问题规模：还剩余left-1个'(',right个')'
            }

            if (right > 0)
            {
                str[pos] = ')';
                Helper(ref list, left, right - 1, ref str, pos + 1);//缩小问题规模：还剩余left个'(',right-1个')'
            }
        }


        //Solution 2 with Hashtable
        public IList<string> GenerateParenthesisWithHashTable(int n)
        {
            List<string> resultList = new List<string>();
            if (n <= 0)
                return resultList;

            if (n == 1)
            {
                resultList.Add("()");
                return resultList;
            }

            //正序面不好处理，可以考虑逆序
            IList<string> preList = GenerateParenthesisWithHashTable(n - 1);
            HashSet<string> hashSet = new HashSet<string>();
            StringBuilder sb =new StringBuilder();
            
            foreach (string s in preList)
            {
                for (int i = 0; i <= s.Length; i++)
                {
                    sb.Clear();
                    sb.Append(s);
                    sb.Insert(i, "()");//机智：因为可行解里必然是以‘（）’为基元，然后穿插叠加起来，所以可以靠不同位置插入此基元，来形成可行解。我还是观察的不够仔细啊。

                    var str = sb.ToString();
                    if (!hashSet.Contains(str))
                    {
                        resultList.Add(str);
                        hashSet.Add(str);
                    }
                }
            }

            return resultList;
        }

    }
}

