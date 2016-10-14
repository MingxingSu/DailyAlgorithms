using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15_3Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //List<string> testData0 =
            //    new List<string>() {"MCDLXXVI", "IV", "V", "VII", "XXIX", "LV", "XCIX"};

            List<int> testData =
                new List<int>() {-4, -2, 1, -5, -4, -4, 4, -2, 0, 4, 0, -2, 3, 1, -5, 0};

            //testData =new List<int>() {0, 0, 0};
            var solution = new Solution();

            var startTime = System.DateTime.Now;

            var result = solution.ThreeSum_V2(testData.ToArray());

            Console.WriteLine("Execution Time(ms):"+ (DateTime.Now - startTime).TotalMilliseconds);

            Console.WriteLine("Input List:" + string.Join(",", testData));

            Console.WriteLine("Results:"); 
            foreach (IList<int> r in result)
            {
                Console.WriteLine(string.Join(",", r));
            }
            Console.Read();
        }




        public class Solution
        {
            //Solution is what I written, but not working for some instances, thus this is not the correct solution.
            public IList<IList<int>> ThreeSum(int[] nums)
            {
                IList<IList<int>> tripletsList = new List<IList<int>>();
                if (nums.Length < 3)
                {
                    return tripletsList;
                }

                var list = new List<int>(nums);
                list.Sort();
                
                
                int left = 0, right = nums.Length - 1;
                int zeroCounter = 0;
                
                while (left < right-2)
                {
                    int leftElement = list[left];
                    if (leftElement == 0)
                    {
                        zeroCounter++;
                    }
                    if (leftElement <= 0)//此处leftElement=0没考虑到
                    {
                        //降低问题的维度--3Sum ->2Sum
                        if (leftElement !=0 && (left < 1 || list[left] != list[left - 1])) //初次去重
                        {
                            TwoSum(list, -leftElement, left + 1, right, ref tripletsList);
                        }
                        left++;
                    }
                    else
                        break;                    
                }
                if (zeroCounter >= 3)
                {
                    tripletsList.Add(new List<int>(){0,0,0});
                }

                return tripletsList;
            }

            //不需要改变list的值，所以
            //ref IList<IList<int>> resultList,当调用子方法返回值和父函数一样，而且需要合并结果时，可以考虑ref引用传入子方法。
            public void TwoSum(IList<int> list, int sum, int left, int right,ref IList<IList<int>> resultList )
            {
                while (left < right)
                {
                    int leftElement = list[left];

                    if (leftElement <= sum)//此处leftElement=sum没考虑到
                    {
                        int tempSum = list[right]  + leftElement;
                        if (tempSum < sum)
                        {
                            left++;//这儿也有问题
                        }
                        else if (tempSum == sum)
                        {
                            //二次去重
                            if (resultList.Any(r => r.Contains(list[left]) && r.Contains(list[right])) == false)
                            {
                                resultList.Add(new List<int>() { -1 * sum, list[left], list[right] });
                            }
                            left++;
                            right--;
                        }
                        else
                        {
                            right--;//这儿也有问题
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }


            //Solution from internet， 
            public IList<List<int>> ThreeSum_V2(int[] nums)
            {
                IList<List<int>> result = new List<List<int>>();
                
                int len = nums.Length;
                if (len < 3) return result;//处理无效输入

                var list = new List<int>(nums);
                list.Sort();//排序

                int i = 0;

                //i指针指向Tuple的第一个元素
                while (i < len - 2)//指针指向的位置不用考虑最后两个元素了，因为长度不够。
                {
                    //首、尾两个元素作为Tuple中第二，第三个元素的候选
                    int start = i + 1, end = len - 1;

                    while (start < end)
                    {
                        int sum = list[i] + list[start] + list[end];
                        if (sum == 0)
                        {
                            result.Add(new List<int>() {list[i], list[start], list[end]});

                            //移动前、后指针，并去重
                            do
                            {
                                end--;
                            } while (end > start && list[end] == list[end + 1]);

                            do
                            {
                                start++;
                            } while (start < end && list[start] == list[start - 1]);
                        }
                        else if (sum > 0)
                        {
                            //移动后指针，并去重
                            do
                            {
                                end--;
                            } while (end > start && list[end] == list[end + 1]);
                        }
                        else
                        {
                            //移动前指针，并去重
                            do
                            {
                                start++;
                            } while (start < end && list[start] == list[start - 1]);
                        }
                    }

                    //外层去重，对于重复值来说，始终只有第一个值被使用在和值的计算中，其余均被删除。
                    do
                    {
                        i++;
                    } while (i < len - 2 && list[i] == list[i - 1]);
                }

                return result;
            }
        }


    }
}

