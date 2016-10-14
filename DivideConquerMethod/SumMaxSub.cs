using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivideConquerMethod
{
    //Find the contiguous subarray within an array (containing at least one number) which has the largest sum.

    //For example, given the array [−2,1,−3,4,−1,2,1,−5,4],
    //the contiguous subarray [4,−1,2,1] has the largest sum = 6.
    public class SumMaxSub
    {
        //Beat 87%,
        public  double CalculateSumMaxSub(double[] nums)
        {
            if (nums.Length == 1)
                return nums[0];

            double globalMax = 0.0;
            double suffixMax = 0.0;
            bool isPositiveFound = false;
            foreach (double num in nums)
            {
                //引入flag非常重要，能够避免不必要的后续line#30~35的全负数处理,极大的提高了性能
                if (!isPositiveFound && num > 0)
                {
                    isPositiveFound = true;
                }

                if (num + suffixMax > globalMax)//对最大值有正面促进
                {
                    suffixMax += num;
                    globalMax = suffixMax;
                }
                else if (num + suffixMax > 0)//对最大值有负面影响，但还不至于让最大值破产
                {
                    suffixMax += num;
                }
                else
                {
                    suffixMax = 0;//最大值破产
                }
            }
            if (globalMax == 0 && !isPositiveFound)
            {
                if (nums.All(n => n < 0))
                {
                    return nums.Max(r => r);
                }
            }
            return globalMax;
        }
    }
}
