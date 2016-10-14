using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace _32_LongestValidParentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            List<string> testData = new List<string>() {"(((()())(()((","()(()", "", "(", ")","()", "(()", ")(())" };

            foreach (var s in testData)
            {
                Console.WriteLine("{0} :'s longest valid parentheses's length is :{1}", s, solution.longestValidParentheses_dp(s));
            }
            Console.Read();
        }
    }
    public class Solution
    {
        //Beat 66.67%

        //DP based solution, O(N) time O(N) space
        //We can do DP: dp[i] saves the longest valid parentheses that ends at (i-1). 
        //To calculate the longest valid parentheses that ends at i (i.e. calculate dp[i+1]), we only need to consider the following cases 
            //1) case 1: s[i] = '(', then no valid parentheses that ends at i, so dp[i+1]=0 (i.e. do nothing) 
            //2) case 2 s[i]= ')' , then we have to check if this ')' can find a matched '(' just before the longest parentheses ending at i-1 (i.e. check if s[i-dp[i]-1] = '(');
                //if yes, then s[i] extends the longest parentheses ending at i-1 to [i-dp[i]-1, i] and it now connects to the longest parentheses ending at i-dp[i]-2, so the DP update equation becomes dp[i+1] =dp[i]+2+dp[i-dp[i]-1]
                //if no, then no valid parentheses ending at i, so dp[i+1] =0 (do nothing)
        public int longestValidParentheses_dp(string s)
        {
            int i, res = 0;
            int[] dp = new int[s.Length + 1];

            for (i = 1; i < s.Length; ++i)
            {
                if (s[i] == ')')
                {
                    //计算上次dp的位置,Longest valid parentheseis的左边界
                    int left = i - dp[i] - 1;

                    if (left >= 0 && s[left] == '(')//上次位置不要超出数组的起始位置，同时找到一个匹配的左括号
                        dp[i + 1] = dp[i] + 2 + dp[left];//这次的dp值是抛掉一个最小规模解后的上次dp值，加最小解，以及
                    res = Math.Max(res, dp[i + 1]);
                }
            }
            return res;
        }




        //Beat 34%
        public int LongestValidParentheses(string s)
        {
            int max = 0, start=0;
            int[] arr = new int[s.Length];
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < s.Length; i++)
            {
                if(s[i]=='(')
                    stack.Push(i);//把左括号的位置入栈
                else if(s[i] ==')')
                {
                    if (stack.Count > 0)//栈空时不管，因为有效的括号对肯定是以左括号作为开始。
                    {
                        start = stack.Pop();//弹出最近的左括号位置

                        arr[i] = i-start +1; //记录当前位置的dp值，i-start肯定为1
                        
                        if(start > 1)
                            arr[i] += arr[start-1];//当前dp值加上，刨去了一个最小有效单元后的上次的dp值作为新值
                    }
                    max = Math.Max(max, arr[i]);//计算最大值
                }
            }
            return max;
        }

        //这个也很巧妙
        public int longestValidParentheses_V2(String s)
        {
            int result = 0;
            int temp = 0;
            Stack<int> stack = new Stack<int>();
            int[] data= new int[s.Length];
            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                if (c == '(') stack.Push(i);
                else
                {
                    if (stack.Count > 0)
                    {
                        data[i] = 1;//把右括号对应的数组值变成1
                        data[stack.Pop()] = 1;//把左括号对应的数组值变成1
                    }
                }
            }
            foreach (int i in data)
            {
                if (i == 1) temp++;
                else
                {
                    result = Math.Max(temp, result);
                    temp = 0;
                }
            }
            return Math.Max(temp, result);
        }
    }
}
