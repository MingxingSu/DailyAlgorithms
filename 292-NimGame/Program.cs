using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _292_NimGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            int[] nums = new[] {0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10};

            foreach (int n in nums)
            {
                Console.WriteLine("Stones Count:{0}, You will win or not:{1}", n, s.CanWinNim(n));
            }
            Console.Read();
        }
    }
    public class Solution
    {
        /*
         * 
        数量	我	对手
        1	yes	no
        2	yes	no
        3	yes	no
        4	no	yes
        5	yes	no
        6	yes	no
        7	yes	no
        8	no	yes
        9	yes	no
        
         */
        //枚举答案，发现规律有时是实现算法的有效途径。
        public bool CanWinNim(int n)
        {
            if (n < 4) return true;
            return n%4 != 0;
        }
    }
}
