using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _219_ContainsDuplicationII
{
    class Program
    {
        static void Main(string[] args)
        {
            //Beat 98.88%
        }
    }
    //Given an array of integers and an integer k, 
    //find out whether there are two distinct indices i and j in the array such that nums[i] = nums[j] and the difference between i and j is at most k.
    public class Solution
    {
        //思路：遇到查重的问题，第一个想法就是hashtable
        public bool ContainsNearbyDuplicate(int[] nums, int k)
        {
            if (nums == null || nums.Length < 2)//此处不要想当然地nums.Length <= k
                return false;
            Dictionary<int, int> dict = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (dict.ContainsKey(nums[i]))
                {
                    if (i - dict[nums[i]] <= k)
                    {
                        return true;
                    }
                    else//这个分支起初没想到，后来在写test cases时想到会有多次重复，第一次不满足返回条件时要更新字典，如[1,2,3,4,2,5,2], k=2，得到的启发：1.TDD的确有助于写出健壮的代码，2. 每一个分支都不要轻易跳过去，要仔细思考可能性。
                    {
                        dict[nums[i]] = i;
                    }
                }
                else
                    dict.Add(nums[i], i);
            }
            return false;
        }
    }
}
