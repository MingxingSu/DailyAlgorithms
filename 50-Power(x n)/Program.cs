using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _50_Power_x_n_
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();

            List<int> numsList = new List<int>(){-2,-1,0,1,2,3};
            double x = 5;

            foreach (int n in numsList)
            {
                Console.WriteLine("Power({0},{1}) is :{2}", x, n, solution.MyPow(x, n));
            }

            Console.Read();
        }
    }
    public class Solution
    {
        //Divide and conquer,折半计算
        public double MyPow(double x, int n)
        {
            if (n==0) return 1;
            if (n == 1) return x;
            if (n == -1) return 1/x;
            double half = MyPow(x, n/2);
            return MyPow(x, n%2)*half*half;
        }
    }

}
