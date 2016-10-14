using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace _17_LetterCombinationsof_PhoneNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> testData = new List<string>() {"2345","","0","13811" };

            var s = new Solution();
            foreach (string str in testData)
            {
                Console.WriteLine("Input String:{0}, LetterCombinations: {1}", str, String.Join("|",s.LetterCombinations(str)));
            }
            Console.Read();
        }
    }

    public class Solution
    {

        //Given a digit string, return all possible letter combinations that the number could represent.

        //A mapping of digit to letters (just like on the telephone buttons) is given below.


        //Input:Digit string "23"
        //Output: ["ad", "ae", "af", "bd", "be", "bf", "cd", "ce", "cf"].
        //Note:
        //Although the above answer is in lexicographical order, your answer could be in any order you want.
        public IList<string> LetterCombinations(string digits)
        {
            List<string> letterCombs = new List<string>();

            if (string.IsNullOrEmpty(digits) || digits.Contains('0') || digits.Contains('1'))
                return letterCombs;

            int len = digits.Length;
            if (len == 1)
            {
                return Dict[digits[0]];
            }
            
            //分置算法：Divide
            int mid =  len / 2;
            
            //Divide and conquer
            letterCombs = CombineLetters(LetterCombinations(digits.Substring(0, mid)), 
                LetterCombinations(digits.Substring(mid)));//Recusively call
            
            return letterCombs;
        }

        //合并两个列表（分置算法：Combine）
        private List<string> CombineLetters(IList<string>  leftList , IList<string> rightList)
        {
            List<string> resultList = new List<string>();

            foreach (var l in leftList)
            {
                resultList.AddRange(rightList.Select(r => l + r));
            }
            return resultList;
        }

        private static readonly Dictionary<char, List<string>> Dict = null;

        static Solution()
        {
            Dict = new Dictionary<char, List<string>>(10)
            {
                {'0', new List<string>() {""}},
                {'1', new List<string>() {""}},
                {'2', new List<string>() {"a", "b", "c"}},
                {'3', new List<string>() {"d", "e", "f"}},
                {'4', new List<string>() {"g", "h", "i"}},
                {'5', new List<string>() {"j", "k", "l"}},
                {'6', new List<string>() {"m", "n", "o"}},
                {'7', new List<string>() {"p", "q", "r", "s"}},
                {'8', new List<string>() {"t", "u", "v"}},
                {'9', new List<string>() {"w", "x", "y", "z"}}
            };
        }

    }
}


