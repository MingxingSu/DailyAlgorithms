using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace _03_LongestNonRepeatSubStr
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var input = "abcdabefgabbaedf";
            int longestLenght = LengOfLongestSubStringV2(input);
            Console.WriteLine("Input String:" + input);
            Console.WriteLine("Longest SubString's length is:"+ longestLenght);
            Console.Read();
        }

        private static int LengOfLongestSubString(string s)
        {
            int _globalMax = 0;
            int _tempMax = 0;
            int _startIndex = 0;

			//要用Dictionary<int,int>,不用Hashtable,避免装箱
			Dictionary<int, int> dict = new Dictionary<int, int>();

			for (int i = 0; i < s.Length; i++)
            {
                if (!dict.ContainsKey(s[i]))
                {
                    dict[s[i]] = i;
                    _tempMax ++;
                }
                else
                {
                    int dupCharIndex = (int)dict[s[i]];
                    _startIndex = _startIndex > dupCharIndex ? _startIndex : dupCharIndex;//从重复元素开始算新的TempMax,但是如果重复元素在StartIndex之前，但不影响StartIndex，因为已经不再考虑那个前面那段。
                    _tempMax = i - _startIndex;//当前位置到重复元素起始位置。
                    dict[s[i]] = i;
                }
                if (_tempMax > _globalMax)
                {
                    _globalMax = _tempMax;
                }

            }

            return _globalMax;
        }

		private static int LengOfLongestSubStringV2(string s)
		{

			Dictionary<int,int> dict = new Dictionary<int, int>();

			for (int i = 0; i < s.Length; i++)
			{
				if (!dict.ContainsKey(s[i]))
				{
					dict[s[i]] = i;
				}
			}

			return dict.Count();
		}
	}

     

}
