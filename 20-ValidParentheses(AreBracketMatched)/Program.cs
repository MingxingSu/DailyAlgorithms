using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20_ValidParentheses_AreBracketMatched_
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> testData = new List<string>() {"]","(", "()","(]","", "()[]{}", "{[()]}","[{]}" };

            var s = new Solution();
            foreach (string str in testData)
            {
                Console.WriteLine("Input String:{0} ;\r\nAre the brackets matched?: {1}", str, String.Join("|", s.IsValid(str)));
            }
            Console.Read();
        }
    }
    public class Solution
    {
        public bool IsValid(string s)
        {
            bool isValid = true;
            var stack = new Stack<char>();

            foreach (char c in s)
            {
                if (IsLeftBracket(c))
                {
                    stack.Push(c);
                }
                else if (IsRightBracket(c))
                {
                    //判断栈空应该用Count==0
                    if (stack.Count == 0 || 
                        !isMatched(stack.Pop(), c))//注意参数顺序
                    {
                        isValid = false;
                        break;
                    }
                }
            }

            return isValid && stack.Count==0;//再次验栈是否为空是为了处理没有任何右括号的情况。
        }

        private bool IsLeftBracket(char c)
        {
            return c == '(' || c == '[' || c == '{';
        }
        private bool IsRightBracket(char c)
        {
            return c == ')' || c == ']' || c == '}';
        }
        

        private bool isMatched(char c1, char c2)
        {
            //注意参数顺序
            return (c1 == '(' && c2 == ')') ||
                   (c1 == '[' && c2 == ']') ||
                   (c1 == '{' && c2 == '}');
        }
    }
}
