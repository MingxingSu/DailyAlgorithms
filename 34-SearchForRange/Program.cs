using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _34_SearchForRange
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            int[] nums = {1, 3,3,3,4,4,5, 5, 6,7,8,8,8,8,9,9,9,15,16,17,29,33,35};
            int target = 8;
             var now = DateTime.Now;
             var result = solution.SearchRangeV2(nums, target);
            Console.WriteLine("Find '{0}' in array '{1}', the insert position is:{2}, execution time is {3}",target,String.Join(",",nums),String.Join(",",result),(DateTime.Now - now).TotalMilliseconds);

            target = 3;
            now = DateTime.Now;
            result = solution.SearchRangeV2(nums, target);
            Console.WriteLine("Find '{0}' in array '{1}', the insert position is:{2}, execution time is {3}",target,String.Join(",",nums),String.Join(",",result),(DateTime.Now - now).TotalMilliseconds);

            int[] nums2 = {1,1,1,1,1,1};
            target = 1;
            now = DateTime.Now;
            result = solution.SearchRangeV2(nums2, target);
            Console.WriteLine("Find '{0}' in array '{1}', the insert position is:{2}, execution time is {3}", target, String.Join(",", nums2), String.Join(",", result), (DateTime.Now - now).TotalMilliseconds);

            nums2 = new int[]{0,0,1,1,1,2,4,4,4,4,5,5,5,6,8,8,9,9,10,10,10};
            target = 8;
            now = DateTime.Now;
            result = solution.SearchRangeV2(nums2, target);
            Console.WriteLine("Find '{0}' in array '{1}', the insert position is:{2}, execution time is {3}", target, String.Join(",", nums2), String.Join(",", result), (DateTime.Now - now).TotalMilliseconds);

            nums2 = new int[] { 1,2,3 };
            target = 2;
            now = DateTime.Now;
            result = solution.SearchRangeV2(nums2, target);
            Console.WriteLine("Find '{0}' in array '{1}', the insert position is:{2}, execution time is {3}", target, String.Join(",", nums2), String.Join(",", result), (DateTime.Now - now).TotalMilliseconds);

            nums2 = new int[] { 2, 2};
            target = 2;
            now = DateTime.Now;
            result = solution.SearchRangeV2(nums2, target);
            Console.WriteLine("Find '{0}' in array '{1}', the insert position is:{2}, execution time is {3}", target, String.Join(",", nums2), String.Join(",", result), (DateTime.Now - now).TotalMilliseconds);

            nums2 = new int[] {1, 2, 2 };
            target = 2;
            now = DateTime.Now;
            result = solution.SearchRangeV2(nums2, target);
            Console.WriteLine("Find '{0}' in array '{1}', the insert position is:{2}, execution time is {3}", target, String.Join(",", nums2), String.Join(",", result), (DateTime.Now - now).TotalMilliseconds);

            nums2 = new int[] { 1, 1, 2 };
            target = 1;
            now = DateTime.Now;
            result = solution.SearchRangeV2(nums2, target);
            Console.WriteLine("Find '{0}' in array '{1}', the insert position is:{2}, execution time is {3}", target, String.Join(",", nums2), String.Join(",", result), (DateTime.Now - now).TotalMilliseconds);
            Console.Read();
        }
    }
    public class Solution
    {
        //我第一次的实现，非常的复杂，而且有非常多的异常状况要处理。最后放弃。重新思考解决思路。考虑使用递归，但写的过程中，发现不用递归也已经得出解决方案，而且非常简洁易懂。

        //缺点：当元素全部相同时，效率退化为O(n)
        public int[] SearchRangeV2(int[] nums, int target)
        {
            //处理异常和基本状况
            int[] results = { -1, -1 };
            if (nums == null || nums.Length == 0) return results;
            if (nums.Length == 1)
            {
                if (nums[0] == target)
                {
                    results[0] = 0;
                    results[1] = 0;
                }
                return results;
            }

            int start = 0;
            int end = nums.Length -1;
            while (start <= end)
            {
                int mid = (start + end) / 2;

                //找到有个有效点之后不再使用折半的思路，而转而用线性方式，以此为中点，往两侧延伸，找到上下边界。
                if (nums[mid] == target)
                {
                    int uppper = mid, lower = mid;
                    while (uppper < end && nums[++uppper] == target) { }
                    while (lower > start && nums[--lower] == target) { }
                    if (nums[end] == target)
                        uppper++;
                    if (nums[start] == target)
                        lower--;
                    return new[] { lower + 1, uppper - 1 };
                }
                //折半缩小搜索范围
                if (nums[mid] < target) start = mid + 1;
                else end = mid-1;
            }
            return results;
        }

        //这是我第一次的实现，非常的复杂，而且有非常多的异常状况要处理。最后放弃。重新思考解决思路。得出了正确解决方案，清晰明了
        //public int[] SearchRange(int[] nums, int target)
        //{
        //    int[] results = new int[2]{-1,-1};

        //    if (nums == null || nums.Length == 0) return results;
        //    if (nums.Length == 1)
        //    {
        //        if (nums[0] == target)
        //        {
        //            results[0] = 0;
        //            results[1] = 0;
        //        }
        //        return results;
        //    }

        //    int start = 0;
        //    int end = nums.Length - 1;
        //    int lower = -1, uppper = -1;
        //    while (start < end)
        //    {
        //        if (nums[start] == target)
        //            results[0] = start;
        //        if (nums[end] == target)
        //            results[1] = end;
        //        if (nums[start] == target && nums[end] == target)
        //        {
        //            return new[] { start, end };
        //        }

        //        int mid = (start + end) / 2;
        //        if (nums[mid] == target)
        //        {
        //            if (mid> 0&& mid < end && nums[mid - 1] != target && nums[mid + 1] != target)
        //                return new[] {mid, mid};

        //            //在左侧找，并更新结果
        //            if(results[0] ==-1)
        //                lower = Search(ref nums, start, mid, target);
        //            if (lower != -1)
        //                results[0] = lower;

        //            //在右侧找，并更新结果
        //            if (results[1] == -1)
        //                uppper = Search(ref nums, mid+1, end, target);

        //            if (uppper == mid+1)
        //                results[1] = uppper;

        //            if (lower == -1 && mid > 0 && mid < end && nums[mid - 1] < target)
        //                results[0] = mid;
        //        }


        //        //左右都找到了边界，直接退出
        //        if (results[0] >= 0 && results[1] >= 0)
        //            return results;


 
        //        //左侧没找到，而且中点小于目标
        //        if (lower == -1 && nums[mid] <= target) start = mid + 1;

        //        //右侧没找到，而且中点大于目标
        //        if (uppper == -1 && nums[mid] >= target) end = mid; 

        //    }

        //    //只在单侧找到目标
        //    if (results[0] >= 0 && results[1] == -1)
        //        results[1] = results[0];
        //    if (results[0] == -1 && results[1] >=0)
        //        results[0] = results[1];

        //    return results;
        //}


        //private int Search(ref int[] nums, int l, int r, int target)
        //{
        //    if (l == r && nums[l] == target) return l;

        //    int pos = l;
        //    while (l <= r)
        //    {
        //        int mid = (l + r) / 2;
        //        if (nums[mid] == target)
        //        {
        //            pos = mid;
        //            if (l == r)
        //            {
        //                break;
        //            }
        //            if (nums[r] > nums[mid] || nums[l] < nums[mid])
        //                break;
        //        }

        //        if (nums[mid] < target) l = mid + 1;
        //        else r = mid;
        //        if (l == r)
        //        {
        //            break;
        //        }
        //    }
        //    return pos;
        //}
    }
}
