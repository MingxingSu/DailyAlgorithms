using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_ContainerWithMost_Wate
{
    class Program
    {
        private static void Main(string[] args)
        {
            List<int> testData0 =
                new List<int>(){2,1};

            Console.WriteLine("The most water container areas is :" + Solution.MaxArea_V2(testData0.ToArray()));

            List<int> testData = new List<int>() { 2,8,5,4,6,7,9,5,1 };

            Console.WriteLine("The most water container areas is :" + Solution.MaxArea_V2(testData.ToArray()));
            Console.Read();
        }
    }

    public  class Solution
    {
        //Given n non-negative integers a1, a2, ..., an, where each represents a point at coordinate (i, ai). n vertical lines are drawn such that the two endpoints of line i is at (i, ai) and (i, 0). Find two lines, which together with x-axis forms a container, such that the container contains the most water.

        //Note: You may not slant the container.
        public static int MaxArea(int[] height)
        {
            if (height == null || height.Length < 2)
                return 0;

            int tempSum = 0;
            int maxSum = 0;
            int i = 0, j =  height.Length - 1;
            while(i<j)
            {
                if (height[j] >= height[i])
                {
                    tempSum =height[i] * (j - i);
                    i++;
                }
                else
                {
                    tempSum = height[j] * (j - i);//我的思维漏洞：自己假设的a[j]<a[i],而忽视了相反的情况也需要计算tempSum
                    j--;
                }

                if (tempSum > maxSum)
                {
                    maxSum = tempSum;
                }
            }
            return maxSum;
        }

        public static int MaxArea_V2(int[] height)
        {
            int maxSum = 0;
            int i = 0, j = height.Length - 1;
            while (i < j)
            {
                maxSum = Math.Max(maxSum, Math.Min(height[i], height[j])*(j - i));
                if (height[j] > height[i])
                {
                    i++;
                }
                else 
                    j--;
            }
            return maxSum;
        }
    }
}
