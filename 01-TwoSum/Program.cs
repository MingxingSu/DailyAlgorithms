using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_TwoSum
{
    class Program
    {
        /*
         *  Given an array of integers, return indices of the two numbers such that they add up to a specific target.

            You may assume that each input would have exactly one solution.

            Example:
            Given nums = [2, 7, 11, 15], target = 9,

            Because nums[0] + nums[1] = 2 + 7 = 9,
            return [0, 1].
            UPDATE (2016/2/13):
            The return format had been changed to zero-based indices. Please read the above updated description carefully.
         */
        static void Main(string[] args)
        {
            var nums = new [] {0,4,3,0,1};
            var targetSum = 0;

            var result = Solution.TwoSum_V3(nums, targetSum);

            for (int index = 0; index < result.Length;index = index +2)
            {
                Console.WriteLine("[{0},{1}]", result[index], result[index + 1]);
            }

            Console.Read();

        }
    }

    public class Solution
    {
        //最直接的解法
        public static int[] TwoSum(int[] nums, int target)
        {
            if (nums == null || nums.Length == 0)//边界异常处理
            {
                return null;
            }

            List<int> locations = new List<int>();//用来保存找到的一对数值在数组中的位置

            for(int i = 0; i < nums.Length; i++)
            {
                for (int j = i+1; j < nums.Length; j++)//j=i+1第二个指针始终在第一个后面保证了(a,b),(b,a)这种情况
                {
                    bool isMatched = nums[i] + nums[j] == target;//应该是数值相加，而不是index相加
                    if (isMatched)
                    {
                        locations.Add(i);
                        locations.Add(j);
                    }
                }
            }
            return locations.ToArray();
        }

        //使用字典
        public static int[] TwoSum_V2(int[] nums, int target)
        {
            if (nums == null || nums.Length == 0)//边界异常处理
            {
                return null;
            }

            List<int> locations = new List<int>();//用来保存找到的一对数值在数组中的位置
            Dictionary<int, List<int>> numLocationsDictionary = new Dictionary<int, List<int>>();

            for (int i = 0; i < nums.Length; i++)
            {
                //To make sure duplicate number's index was stored under the same key
                if (numLocationsDictionary.ContainsKey(nums[i]))
                {
                    numLocationsDictionary[nums[i]].Add(i);
                }
                else
                {
                    var tempList = new List<int>();
                    tempList.Add(i);
                    numLocationsDictionary.Add(nums[i], tempList);
                }
            }

            for (int i = 0; i < nums.Length; i++)
            {

                if (numLocationsDictionary.ContainsKey(target - nums[i]) && locations.IndexOf(i) ==-1)
                {
                    // If a and b are the same key
                    if (nums[i] == target/2) 
                    {
                        if (numLocationsDictionary[target - nums[i]].Count > 1)
                        {
                            locations.Add(i);
                            locations.Add(numLocationsDictionary[target - nums[i]].ToArray()[1]);
                        }
                    }
                    else
                    {
                        locations.Add(numLocationsDictionary[nums[i]].ToArray()[0]);
                        locations.Add(numLocationsDictionary[target-nums[i]].ToArray()[0]);
                    }
                    
                }
            }
            
            return locations.ToArray();
        }

		//参考别人的思路之后写的
		public static int[] TwoSum_V3(int[] nums, int target)
		{
			int[] res = new int[2];
			Dictionary<int, int> map = new Dictionary<int, int>();
			for (int i = 0; i < nums.Length; i++)
			{
				if (map.ContainsKey(target - nums[i]) && map[target - nums[i]] != i)
				{
					res[1] = i;
					res[0] = map[target - nums[i]];
					break;
				}
				if (!map.ContainsKey(nums[i]))
				{
					map.Add(nums[i], i);
				}
			}
			return res;

		}
	}
}
