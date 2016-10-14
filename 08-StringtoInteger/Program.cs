using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_StringtoInteger
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> testData = new List<string>() {"18446744073709551617","-9223372036854775809","9223372036854775809","2147483648","-2147483648","+1","  -0012a42","    -00134", "-12","123,456" ,"120.043", "0", "123", "0.123"};

            foreach (var s in testData)
            {
                Console.WriteLine("{0}  converted to int is :{1}", s, Solution.StringToInteger(s));
            }
            Console.Read();

            //int tempSumDecimals = 1;
            //if (resultTwoParts.Length > 1)
            //{
            //    //小数部
            //    foreach (char digit in resultTwoParts[1])
            //    {
            //        if (digit == '0')
            //        {
            //            tempSumDecimals /= 10;
            //        }
            //        else tempSumDecimals = tempSumDecimals/10 + (digit - baseLine);
            //    }
            //}

            //合并
        }
    }
    public class Solution
    {
        //这个效率不高，因为过多使用了字符串类库的自带方法，indexof, trim，等操作。而使用它们是基于不清楚需求。在需求清晰时，应该可以想到：开头的无效字符可以靠start指针来跳过去，而数字中间的无效字符，应该是转化停止的标志。
        public static int MyAtoi(string str)
        {
            //1:处理空，加号减号过多
            if (string.IsNullOrEmpty(str) ||
                (str.IndexOf('+') >= 0 && str.IndexOf('-') >= 0) ||
                str.IndexOf('+') != str.LastIndexOf('+') ||
                str.IndexOf('-') != str.LastIndexOf('-')
                )
                return 0;

            //2：清理掉空格，逗号，减号
            string cleanStr = str.TrimStart(' ');
            bool isNegative = cleanStr.StartsWith("-");
            cleanStr = cleanStr.TrimStart('-');

            const int baseLine = '0';
            long result = 0;
            
            //3:处理有小数的情况：忽略掉
            var twoParts = cleanStr.Split('.');

            


            //4:字符转化为数值和
            long tempSum = 0;
            foreach (char digit in twoParts[0])
            {
                //处理非数字字符，如"  -0012a42"
                if (digit >= '0' && digit <= '9')
                {
                    if (tempSum > int.MaxValue)//计算和值时避免long int溢出
                    {
                        break;
                    }
                    tempSum = 10*tempSum + digit - baseLine;

                }
                //非数字，非加号，直接退出转化。
                else if (digit != '+')
                {
                    break;
                }
            }

            //先把符号加上，再计算，因为最大和最小整数字符不一样。
            result = isNegative ? tempSum * -1 : tempSum;

            //处理溢出
            if (isNegative)
            {
                if (result > int.MaxValue || result < int.MinValue)
                {
                    return int.MinValue;
                }
            }
            else
            {
                if (result > int.MaxValue || result < int.MinValue)
                {
                    return int.MaxValue;
                }
            }

            return (int)result;
        }


        //Solution 2: this was done after I read other's code
        public static int StringToInteger(string str)
        {
            if (string.IsNullOrEmpty(str))
                return 0;

            //1:处理空，加号减号过多
            int sig = 1;
            int len = str.Length;
            int start = 0;

            //过滤掉开头的空格和数字0
            for (int i = 0; i <len ; i++)
            {
                if (str[i] == ' ' || str[i] == 0x9) 
                    start++;
                else 
                    break;
            }

            //处理正负符号，以及确定有效数字开始的位置
            if (str[start] == '-')
            {
                sig = -1;
                start++;
            }
            else if (str[start] == '+') { 
                sig = 1;
                start++;
            }


            //4:字符转化为数值和
             uint sum = 0;
            for (int i = start; i <len ; i++)//
            {
                var digit = str[i];

                if (digit >= '0' && digit <= '9')
                {
                    int n = digit - '0';
                    if (int.MaxValue/10 >= sum) //处理进位后的和值溢出
                        sum *= 10;
                    else 
                        return sig == 1 ? int.MaxValue : int.MinValue;

                    if (int.MaxValue - n >= sum) //处理加上个位数后的和值溢出
                        sum += (uint)n;
                    else 
                        return sig == 1 ? int.MaxValue : int.MinValue;

                }
                else //无效数字，停止。
                    break;                
            }

            return sig*((int)sum);

        }
    }
}
