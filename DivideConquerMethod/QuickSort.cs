using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Sort
{

    public class QuickSort
    {
        private readonly int[] _list = null;
 
        public QuickSort(int[] list)
        {
            this._list = list;
        }

        /*
        Do nothing if left <= right
        p <- Get a number from array
        Put elements <= p to the left side
        Put elements >= p to the right side
        Put p in the middle slot which index is pivot
        Recursive quicksort the left parts and right parts
        */ 
        private void Sort(int[] array, int left, int right)
        {
            if (left < right)
            {
                int pivot = left;
                for (int j = left + 1; j <= right; j++)
                {
                    if (array[j] < array[left])
                        Swap(array, ++pivot, j);
                }
                Swap(array, pivot, left); //left of pivot is less that array[left], right of pivot is greater that arrary[left]
                Sort(array, left, pivot - 1);
                Sort(array, pivot + 1, right);
            }
        }


        private void Swap(int[] array,int a, int b)
        {
            int temp = array[b];
            array[b] = array[a];
            array[a] = temp;
        }


        public string GetSortedListString()
        {
            Sort(_list,0,_list.Length-1);
            return String.Join(",", _list);
        }
    }
}
