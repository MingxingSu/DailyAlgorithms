using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _38_CountAndSay
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            int num = 6;
            var now = DateTime.Now;
            string resultStr = solution.CountAndSay(num);

            Console.WriteLine("The {0}th count and say string is :{1}, {2}ms",num,resultStr, (DateTime.Now-now).TotalMilliseconds);

            Console.Read();
        }
    }
    public class Solution
    {
        //Beat 63.33%
        public string CountAndSay(int n)
        {
            if (n < 0) return String.Empty;
            if (n < 2) return "1";

            StringBuilder sb = new StringBuilder("11");
            for (int i=2; i < n; i++)
            {
                var numCounts = new List<int[]>();
                for (int j = 0; j < sb.Length -1; j++)
                {
                    int count = 1;
                    int[] tempArray = new int[2];
                    int sbLen = sb.Length - 1;
                    while (j < sbLen && sb[j + 1] == sb[j])
                    {
                        j++;
                        count++;
                    }
                    tempArray[0] = count;
                    tempArray[1] = int.Parse(sb[j].ToString()); 
                    numCounts.Add(tempArray);
                }
                //deal with the last char
                if (sb[sb.Length - 1] != sb[sb.Length - 2])
                {
                    numCounts.Add(new[] {1, int.Parse(sb[sb.Length - 1].ToString())});
                }

                //重新组装string
                sb.Clear();
                foreach (int[] ints in numCounts)
                {
                    sb.Append(ints[0]);
                    sb.Append(ints[1]);
                }
            }
            return sb.ToString();
        }
    }
}
