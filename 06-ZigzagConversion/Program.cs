using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_ZigzagConversion
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> testData = new List<string>() { "PAYPALISHIRING" };

            foreach (var s in testData)
            {
                Console.WriteLine("Origional input: {0}  , after convert:{1}", s, Convert2(s, 4));
            }
            Console.Read();
        }

        private static string Convert(string s, int numRows)
        {
            int len = s.Length;

            if (string.IsNullOrEmpty(s) || numRows ==0)
                return String.Empty;

            if (!string.IsNullOrEmpty(s) && s.Length <= numRows)
                return s;

            if (!string.IsNullOrEmpty(s) && numRows==1)
                return s;

            int row = 0;

            StringBuilder sb = new StringBuilder();
            
            while (row < numRows -1)
            {
                int nColumn = (len - row)/(2*numRows - 2*row - 2);
                int col = 0;
                while (col <= nColumn)
                {
                    if ((2 * numRows - 2 * row - 2) * col + row > len-1)
                    {
                        break;
                    }
                    sb.Append(s[(2*numRows - 2*row - 2)*col+row]);
                    col++;
                }

                row ++;
            }
            if (row == numRows - 1)//最后一行
            {
                int nColumn = len - sb.Length;//最后一行的总列数，不实用原来的计算方法是因为除数为0
                int col = 0;
                while (col < nColumn)
                {
                    int index= (2 * numRows - 2 ) * col+numRows-1 > len -1  ? len -1 : (2 * numRows - 2 )*col + numRows - 1;

                    sb.Append(s[index]);
                    col++;
                }
            }

            return sb.ToString();
        }

        /*
        rowNums=0
		return 0;
		d[0]=0
		
		rowNums=1
		row 0:0,1,2,3,4 =x
		d[1]=x+d[0]

		rowNums=2
        row 0: index = 0,2,4,6 =2x
        row 1: index =1,3,5,7,9,11,13 =2x+1
		
		d[2-0]=

		rowNums=3
        row 0: index = 0,4,8,12 =4x
        row 1: index =1,3,5,7,9,11,13 =2x+1
        row 2: index=2,6,10,14 =4x+2 
		
		rowNums=4
		
		ow 0: index=0,6,12=6x
        row 1:index=1,5,7,11,13=(4x+1,4x-3
        row 2:index=2,4,8,10,14=
		row 3:index=3,9,15=6x+3

		int n =0;
		while(n<rowNums):
			while((2rowNums-2*(n+1))*i+n<s.len)                                                                                                                                      

		i=0,i=1
         d[j] =
		(2rowNums-2*1)*i+0
		(2rowNums-2*2)*i+1
		(2rowNums-2*3)*i+2
		(2rowNums-2*1)*i+3

        */

        public static string Convert2(string s, int numRows)
        {
            if (numRows < 2)
            {
                return s;
            }
            char[] arr = s.ToCharArray();
            int m = 2 * (numRows - 1);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < numRows; i++)
            {
                ConvertRow(sb, arr, m, i);
            }
            return sb.ToString();
        }

        private static void ConvertRow(StringBuilder sb, char[] arr, int m, int row)
        {
            int len = arr.Length;
            int left = 0 - row, right = row;
            while (true)
            {
                if (left >= len || (left < 0 && right >= len))
                {
                    break;
                }
                if (left >= 0)
                {
                    sb.Append(arr[left]);
                }
                if (right < len && row != 0 && right != left + m)
                {
                    sb.Append(arr[right]);
                }
                left += m;
                right += m;
            }
        }
		
    }

}
