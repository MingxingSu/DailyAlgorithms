using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _35_SearchInsertPosition
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            int[] nums = {1, 3, 5, 6};
            int target = 4;
             var now = DateTime.Now;
            int result = solution.SearchInsert(nums, target);//2
            Console.WriteLine("Find '{0}' in array '{1}', the insert position is:{2}, execution time is {3}",target,String.Join(",",nums),result,(DateTime.Now - now).TotalMilliseconds);

            target = 2;
            now = DateTime.Now;
            result = solution.SearchInsert(nums, target);//1
            Console.WriteLine("Find '{0}' in array '{1}', the insert position is:{2}, execution time is {3}",target,String.Join(",",nums),result,(DateTime.Now - now).TotalMilliseconds);

            target = 7;
            now = DateTime.Now;
            result = solution.SearchInsert(nums, target);//4
            Console.WriteLine("Find '{0}' in array '{1}', the insert position is:{2}, execution time is {3}",target,String.Join(",",nums),result,(DateTime.Now - now).TotalMilliseconds);

            target = 0;
            now = DateTime.Now;
            result = solution.SearchInsert(nums, target);//0
            Console.WriteLine("Find '{0}' in array '{1}', the insert position is:{2}, execution time is {3}",target,String.Join(",",nums),result,(DateTime.Now - now).TotalMilliseconds);

            int[] testData = new int[]{1};
            target = 2;
            now = DateTime.Now;
            result = solution.SearchInsert(testData, target);
            Console.WriteLine("Find '{0}' in array '{1}', the insert position is:{2}, execution time is {3}", target, String.Join(",", testData), result, (DateTime.Now - now).TotalMilliseconds);

            testData = new int[] { 1,3 };
            target = 3;
            now = DateTime.Now;
            result = solution.SearchInsert(testData, target);
            Console.WriteLine("Find '{0}' in array '{1}', the insert position is:{2}, execution time is {3}", target, String.Join(",", testData), result, (DateTime.Now - now).TotalMilliseconds);

            Console.Read();
        }
    }
    public class Solution
    {

        //Beat 58%
        public int SearchInsert(int[] nums, int target)
        {
            if (nums == null || nums.Length ==0) return 0;
            if (nums.Length == 1) return nums[0] >= target ? 0 : 1;

            int start = 0;
            int end = nums.Length - 1;
            while (start < end)
            {
                //(end - start == 1 && nums[end] >= target && nums[start] < target) return end;这个只是个特例，可以被mid,mid+1覆盖
                int mid = (start + end)/2;
                if (nums[mid] == target) return mid;//刚好是中间节点
                if (nums[mid + 1] >= target && nums[mid] < target) return mid + 1;

                //折半
                if (nums[mid] < target) start = mid + 1;
                else end = mid;
            }
            return end > 0 ? end + 1 : end;
        }
    }
}
