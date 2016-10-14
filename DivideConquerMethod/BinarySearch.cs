using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class BinarySearch
    {
        /// <summary>
        /// 二分查找，O(logN)
        /// </summary>
        /// <param name="array">数组</param>
        /// <param name="length">数组长度</param>
        /// <param name="value">待查找的值</param>
        /// <returns></returns>
        public static int BinSearch(int[] array, int length, int value)
        {
            int left = 0;
            int right = length - 1;//最后一个元素

            while (left <= right) //右指针和左指针交错时退出
            {
                int middle = left + ((right - left) >> 1);//右移比较安全，防止end+start的和值溢出

                if (array[middle] < value)
                {
                    left = middle + 1;
                }
                else if (array[middle] > value)
                {
                    right = middle - 1;
                }
                else
                {
                    return array[middle];//找到了
                }
            }
            return -1;//没找到
        }
		
		//分治思想
		public static int BinSearch2(int[] array, int left, int right, int value)
        {
            if (left <= right) //右指针和左指针交错时退出
            {
                int middle = left + ((right - left) >> 1);//右移比较安全，防止end+start的和值溢出
				
                if (array[middle] < value)
                {
                    BinSearch2(array, middle + 1, right,value);
                }
                else if (array[middle] > value)
                {
					BinSearch2(array, left, middle - 1,value);
                }
                else
                {
                    return array[middle];//找到了
                }
            }
            return -1;//没找到
        }


    }
}
