using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;

namespace _07_ReverseInteger
{
    class Program
    {
        static void Main(string[] args)
        {
            int x1 = 1534236469;
            int r1 = Reverse_Best(x1);
            Console.WriteLine("{0}: reverse result: {1}", x1, r1);

            int x2 = -123;
            int r2 = Reverse_Best(x2);
            Console.WriteLine("{0}: reverse result: {1}", x2, r2);

            int x3 = -2147483648;
            int r3 = Reverse_Best(x3);
            Console.WriteLine("{0}: reverse result: {1}", x3, r3);

            int x4 = 1000;
            int r4 = Reverse_Best(x4);
            Console.WriteLine("{0}: reverse result: {1}", x4, r4);
            Console.Read();

        }
        //1.stringbuilder, %运算
        private static int Reverse(int x)
        {
            if (x == 0 || 
                x == int.MinValue ||
                x == int.MaxValue)
            {
                return 0;
            }

            while (x%10==0)
            {
                x /= 10;
            }

            if (x < 10 && x > -10)
            {
                return x;
            }

            int positiveX = Math.Abs(x);
            StringBuilder sb = new StringBuilder();
            if (x < 0)
            {
                sb.Append("-");
            }
            while (positiveX > 0)
            {
                int r = positiveX % 10;
                sb.Append(r);

                positiveX = positiveX / 10;
            }

            Int64 reverseInt = Int64.Parse(sb.ToString());
            if (reverseInt > Int32.MaxValue ||
                reverseInt < Int32.MinValue)
            {
                return 0;
            }

            return (int) reverseInt;
        }

        //2.倒序输出
        private static int Reverse2(int x)
        {
                if (x == 0 ||
                    x == int.MinValue ||
                    x == int.MaxValue)
                {
                    return 0;
                }
                while (x % 10 == 0)
                {
                    x /= 10;
                }
                if (x < 10 && x > -10)
                {
                    return x;
                }

                var orginalStr = x < 0 ? x.ToString().Substring(1) : x.ToString();
                var reverseStr = x < 0 ? "-" : "";
            
                for (int i = orginalStr.Length - 1; i >= 0; i--)
                {
                    reverseStr += orginalStr[i];
                }

                Int64 reverseInt = Int64.Parse(reverseStr);
                if (reverseInt > Int32.MaxValue ||
                    reverseInt < Int32.MinValue)
                {
                    return 0;
                }

                return (int)reverseInt;
        }

        //3.list
        private static int Reverse3(int x)
        {
            if (x == 0 ||
                x == int.MinValue ||
                x == int.MaxValue)
            {
                return 0;
            }
            while (x % 10 == 0)
            {
                x /= 10;
            }
            int postiveX = Math.Abs(x);
            if (postiveX < 10)
            {
                return x;
            }

            var orginalStr = postiveX.ToString();
            var reverseStr = x < 0 ? "-" : "";
            List<char> list = new List<char>(orginalStr.Length);
            for (int i = orginalStr.Length - 1; i >= 0; i--)
            {
                list.Add(orginalStr[i]);
            }
            reverseStr += new string(list.ToArray());
            Int64 reverseInt = Int64.Parse(reverseStr);
            if (reverseInt > Int32.MaxValue ||
                reverseInt < Int32.MinValue)
            {
                return 0;
            }

            return (int)reverseInt;
        }

        //4.Queue

        //5.字符串原地逆转
        private static int Reverse5(int x)
        {
            if (x == 0 ||
                x == int.MinValue ||
                x == int.MaxValue)
            {
                return 0;
            }
            while (x % 10 == 0)
            {
                x /= 10;
            }
            int postiveX = Math.Abs(x);
            if (postiveX < 10)
            {
                return x;
            }

            var orginalStr = postiveX.ToString().ToCharArray();
            var reverseStr = x < 0 ? "-" : "";
            for (int i = 0, j=orginalStr.Length -1; i < j; i++,j--)
            {
                char t = orginalStr[j];
                orginalStr[j] = orginalStr[i];
                orginalStr[i] = t;
            }
            reverseStr += new string(orginalStr);

            Int64 reverseInt = Int64.Parse(reverseStr);
            if (reverseInt > Int32.MaxValue ||
                reverseInt < Int32.MinValue)
            {
                return 0;
            }

            return (int)reverseInt;
        }

        //Best
        private static int Reverse_Best(int x)
        {
            bool neg = false;

            if (x < 0)
            {
                neg = true;
                x = -x;
            }

            ulong ret = 0;

            while (x / 10 > 0)
            {
                ret = ret * 10 + (ulong)x % 10;

                x = x/10;
            }

            ulong final = (ret * 10) + (ulong)x;
            if (final > int.MaxValue)
                return 0;
            if (neg) return -(int)final;
            return (int)final;
        }

    }
}
