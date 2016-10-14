using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _29_DivideTwoIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            int dividend = -5;
            int divisor = 2;

            Console.WriteLine("Dividend: '{0}' ,Divisor:'{1}' , Result: {2}", dividend, divisor, solution.Divide(dividend, divisor));

            dividend = 0;
            divisor = 2;
            Console.WriteLine("Dividend: '{0}' ,Divisor:'{1}' , Result: {2}", dividend, divisor, solution.Divide(dividend, divisor));


            dividend = -1;
            divisor = -1;
            Console.WriteLine("Dividend: '{0}' ,Divisor:'{1}' , Result: {2}", dividend, divisor, solution.Divide(dividend, divisor));

            dividend = 5;
            divisor = -2;
            Console.WriteLine("Dividend: '{0}' ,Divisor:'{1}' , Result: {2}", dividend, divisor, solution.Divide(dividend, divisor));

            dividend = 10;
            divisor = 2;
            Console.WriteLine("Dividend: '{0}' ,Divisor:'{1}' , Result: {2}", dividend, divisor, solution.Divide(dividend, divisor));

            dividend = 1;
            divisor = -1;
            Console.WriteLine("Dividend: '{0}' ,Divisor:'{1}' , Result: {2}", dividend, divisor, solution.Divide(dividend, divisor));

            dividend = 1;
            divisor = 0;
            Console.WriteLine("Dividend: '{0}' ,Divisor:'{1}' , Result: {2}", dividend, divisor, solution.Divide(dividend, divisor));

            dividend = -2147483648;
            divisor = -1;
            Console.WriteLine("Dividend: '{0}' ,Divisor:'{1}' , Result: {2}", dividend, divisor, solution.Divide(dividend, divisor));

            dividend = 1;
            divisor = -2147483648;
            Console.WriteLine("Dividend: '{0}' ,Divisor:'{1}' , Result: {2}", dividend, divisor, solution.Divide(dividend, divisor));

            dividend = 2147483647;
            divisor = 2;
            Console.WriteLine("Dividend: '{0}' ,Divisor:'{1}' , Result: {2}", dividend, divisor, solution.Divide(dividend, divisor));

            dividend = -2147483648;
            divisor = 1;
            Console.WriteLine("Dividend: '{0}' ,Divisor:'{1}' , Result: {2}", dividend, divisor, solution.Divide(dividend, divisor));

            dividend = -2147483648;
            divisor = 2;
            Console.WriteLine("Dividend: '{0}' ,Divisor:'{1}' , Result: {2}", dividend, divisor, solution.Divide(dividend, divisor));

            dividend = -2147483648;
            divisor = 1262480350;
            Console.WriteLine("Dividend: '{0}' ,Divisor:'{1}' , Result: {2}", dividend, divisor, solution.Divide(dividend, divisor));

            dividend = -2147483648;
            divisor = -2147483648;
            Console.WriteLine("Dividend: '{0}' ,Divisor:'{1}' , Result: {2}", dividend, divisor, solution.Divide(dividend, divisor));

            Console.Read();
        }
    }

    //beat 49%'s submissions
    public class Solution
    {
        //Divide two integers without multiplication, divide, and mod operations
        public int Divide(int dividend, int divisor)
        {
            //除数为0时
            if (divisor == 0)
                return Int32.MaxValue;

            if ((dividend >= 0 && dividend < divisor) ||//被除数为正，但是比除数小
                (dividend !=divisor && divisor == int.MinValue))//被除数不为最小负数，除数是最小负数时
                return 0;

            //被除数是最小负数时
            if (dividend == int.MinValue)
            {
                if (divisor == 1) return int.MinValue;
                if (divisor == -1) return int.MaxValue;
                if (divisor == int.MinValue) return 1;
            }

            //保存结果的正负号
            int sig = 1;
            if ((dividend < 0 && divisor > 0) || (dividend > 0 && divisor < 0))
                sig = -1;

            //保存结果
            int result = 0;
            int startPosDivide = dividend < 0 ? 1 : 0;

            //按字符串处理
            string dividenStr = dividend.ToString().Substring(startPosDivide);
            divisor = divisor == int.MinValue ? int.MaxValue : Math.Abs(divisor);//转化时始终要考虑是否会溢出。

            string resultStr = "";
            int remainder =0;
            foreach (char n in dividenStr)
            {
                string tempDigit = n.ToString();

                if (remainder > 0)//考虑高位的余数
                    tempDigit = remainder+ tempDigit;

                int tempDividend = Int64.Parse(tempDigit) > int.MaxValue ? Int32.MaxValue :int.Parse(tempDigit);//转化时始终要考虑是否会溢出。

                int tempResult = GetDivideRemainder(tempDividend, divisor, ref remainder);

                resultStr += tempResult.ToString();
            }

            return int.Parse(resultStr) * sig;
        }

        //Divide two integers without multiplication, divide, and mod operations
        //this can be applicable for small dividends, and will time out when dividen is too big and divisor is too small, it will abstract for too many times
        public int GetDivideRemainder(int dividend, int divisor,ref int remainder)
        {
            if (divisor == 0)
                return Int32.MaxValue;

            if (dividend >= 0 && dividend < divisor)
            {
                remainder = dividend;//把remainder余数保存起来，方便和下一位数合成
                return 0;
            }

            int result = 0;

            do
            {
                dividend -= divisor;

                if (dividend >= 0)
                    result++;
                else
                {
                    break;
                }

            } while (dividend >= divisor);

            remainder = dividend;//此时dividen剩下的已经小于divisor

            return result;
        }
    }
}
