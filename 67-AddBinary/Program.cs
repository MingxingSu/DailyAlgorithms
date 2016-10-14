using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _67_AddBinary
{
    class Program
    {
        static void Main(string[] args)
        {
            

            string a ="1010";
            string b= "1011";
            Console.WriteLine("{0} + {1 }= {2}", a,b,AddBinary(a,b));
             
            Console.Read();
        }
        //Beat 93.44% , NB!
        public static string AddBinary(string a, string b)
        {
            String c = "";
            int maxLen = Math.Max(a.Length, b.Length);
            if (a.Length > b.Length)
                b = b.PadLeft(maxLen, '0');
            else
                a = a.PadLeft(maxLen, '0');

            int up = 0;
            for (int i = maxLen - 1; i >= 0; i--)
            {
                int temp = a[i] - '0' + b[i] - '0' + up;
                c = temp % 2 + c;
                up = temp / 2;
            }
            c = up > 0 ? up + c : c;

            return c;
        }
    }
}
